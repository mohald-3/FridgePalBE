using Application.Dtos.Items;
using Application.Interfaces.Services.OpenAI;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Infrastructure.Services.OpenAI
{
    public class OpenAIService : IOpenAIService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public OpenAIService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<AnalyzeImageResponseDto> AnalyzeImageAsync(IFormFile image, CancellationToken cancellationToken)
        {
            if (image == null || image.Length == 0)
                throw new ArgumentException("Image is null or empty.");

            // Convert to base64
            string base64Image;
            using (var ms = new MemoryStream())
            {
                await image.CopyToAsync(ms, cancellationToken);
                var imageBytes = ms.ToArray();
                base64Image = Convert.ToBase64String(imageBytes);
            }

            var base64ImageUrl = $"data:{image.ContentType};base64,{base64Image}";

            var prompt = @"
                            You are a smart fridge assistant.

                            Here is the list of categories you must use:
                            [
                              { ""categoryId"": 1, ""categoryName"": ""Dairy"" },
                              { ""categoryId"": 2, ""categoryName"": ""Meat"" },
                              { ""categoryId"": 3, ""categoryName"": ""Vegetables"" },
                              { ""categoryId"": 4, ""categoryName"": ""Fruits"" },
                              { ""categoryId"": 5, ""categoryName"": ""Fish"" },
                              { ""categoryId"": 6, ""categoryName"": ""Beverages"" },
                              { ""categoryId"": 7, ""categoryName"": ""Frozen"" },
                              { ""categoryId"": 8, ""categoryName"": ""Other"" }
                            ]
                            Estimate the quantity of the item visible in the image (e.g., 1 apple, 3 eggs, 2 bottles). Be realistic but approximate.

                            Based on the image, respond ONLY with valid JSON in the following format:
                            {
                              ""itemName"": ""(name of the item)"",
                              ""categoryId"": (integer, from the list above),
                              ""quantity"": (integer, estimated quantity of the item in the image),

                              ""categoryName"": ""(exact match from above)"",
                              ""shelfLifeDays"": (approximate higher number of days the item lasts in a fridge),
                            }

                            Do not include explanation or markdown — only valid pure JSON.";

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                new
                {
                    role = "user",
                    content = new object[]
                    {
                        new { type = "text", text = prompt },
                        new
                        {
                            type = "image_url",
                            image_url = new { url = base64ImageUrl }
                        }
                    }
                }
            },
                max_tokens = 300
            };

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _configuration["OpenAI:ApiKey"]);

            var json = JsonSerializer.Serialize(requestBody);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", httpContent, cancellationToken);
            response.EnsureSuccessStatusCode();

            //Logging
            var rawContent = await response.Content.ReadAsStringAsync(cancellationToken);
            Console.WriteLine("🔍 OpenAI Raw Response:");
            Console.WriteLine(rawContent);
            var gptResponse = JsonSerializer.Deserialize<OpenAIResponse>(rawContent);

            if (gptResponse?.choices == null || !gptResponse.choices.Any())
                throw new Exception("GPT-4 response is missing choices.");

            var content = gptResponse.choices.First().message?.content;

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new Exception("GPT-4 returned empty content.");
            }

            // Remove markdown wrapping like ```json ... ```
            content = content.Trim();

            if (content.StartsWith("```json"))
            {
                content = content.Substring(7).Trim(); // remove ```json\n
            }
            else if (content.StartsWith("```"))
            {
                content = content.Substring(3).Trim(); // remove ```\n
            }

            if (content.EndsWith("```"))
            {
                content = content.Substring(0, content.Length - 3).Trim(); // remove ending ```
            }

            AnalyzeImageResponseDto? resultDto;

            try
            {
                resultDto = JsonSerializer.Deserialize<AnalyzeImageResponseDto>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }
            catch (JsonException ex)
            {
                Console.WriteLine("❌ JSON parsing error:");
                Console.WriteLine(content);
                throw new Exception("GPT returned invalid JSON format.", ex);
            }

            if (resultDto == null)
                throw new Exception("GPT response could not be mapped to DTO.");

            return resultDto;
        }
    }
}
