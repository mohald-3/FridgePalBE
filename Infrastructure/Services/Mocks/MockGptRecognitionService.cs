using Application.Dtos.Items;
using Application.Interfaces.Services.Mocks;

namespace Infrastructure.Services.Mocks
{
    public class MockGptRecognitionService : IGptRecognitionService
    {
        public Task<RecognizedItemDto> RecognizeItemAsync(string imageUrl)
        {
            // Return hardcoded or random values for testing
            var mockResult = new RecognizedItemDto
            {
                Name = "Mocked Apple",
                Category = "Fruit",
                EstimatedShelfLifeInDays = 7,
                CategoryId = 1
            };

            return Task.FromResult(mockResult);
        }
    }
}
