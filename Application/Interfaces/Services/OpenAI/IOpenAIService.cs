using Application.Dtos.Items;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Services.OpenAI
{
    public interface IOpenAIService
    {
        Task<AnalyzeImageResponseDto> AnalyzeImageAsync(IFormFile image, CancellationToken cancellationToken);
    }
}
