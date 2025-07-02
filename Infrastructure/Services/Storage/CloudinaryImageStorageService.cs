using Application.Interfaces.Services.Images;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.Storage
{
    public class CloudinaryImageStorageService : IImageStorageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryImageStorageService(IOptions<CloudinarySettings> settings)
        {
            var acc = new Account(
                settings.Value.CloudName,
                settings.Value.ApiKey,
                settings.Value.ApiSecret);

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = false
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ApplicationException($"Cloudinary upload failed: {uploadResult.Error?.Message}");

            return uploadResult.SecureUrl.ToString();
        }

        public async Task DeleteImageAsync(string imageUrl)
        {
            var publicId = Path.GetFileNameWithoutExtension(new Uri(imageUrl).AbsolutePath);
            var deletionParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deletionParams);

            if (result.Result != "ok")
                throw new ApplicationException("Cloudinary image deletion failed: " + result.Error?.Message);
        }
    }
}
