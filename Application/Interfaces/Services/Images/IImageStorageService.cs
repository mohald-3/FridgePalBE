using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Services.Images
{
    public interface IImageStorageService
    {
        Task<string> UploadImageAsync(IFormFile file);
    }
}
