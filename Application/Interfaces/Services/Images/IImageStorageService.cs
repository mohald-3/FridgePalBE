using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Services.Images
{
    public interface IImageStorageService
    {
        Task<string> UploadImageAsync(IFormFile file);
        Task DeleteImageAsync(string imageUrl);
    }
}
