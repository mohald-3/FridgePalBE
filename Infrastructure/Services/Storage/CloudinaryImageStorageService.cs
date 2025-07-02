using Application.Interfaces.Services.Images;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLaborsSize = SixLabors.ImageSharp.Size;

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
            var resizedImageBytes = await ResizeImageAsync(file, 400, 400); // resize before uploading

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, new MemoryStream(resizedImageBytes)),
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

        // Resizing helping method
        private async Task<byte[]> ResizeImageAsync(IFormFile uploadedFile, int maxWidth, int maxHeight)
        {
            using var image = await Image.LoadAsync(uploadedFile.OpenReadStream());

            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new SixLaborsSize(maxWidth, maxHeight),
                Mode = ResizeMode.Max
            }));

            using var ms = new MemoryStream();
            await image.SaveAsJpegAsync(ms);
            return ms.ToArray();
        }
    }
}
