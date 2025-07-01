//using Application.Interfaces.Services.Images;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace API.Controllers.CloudinaryTestsController
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CloudinaryTestController : ControllerBase
//    {
//        private readonly IImageStorageService _imageService;

//        public CloudinaryTestController(IImageStorageService imageService)
//        {
//            _imageService = imageService;
//        }

//        [HttpPost("ping")]
//        public async Task<IActionResult> PingCloudinary(IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//                return BadRequest("File is missing.");

//            try
//            {
//                var imageUrl = await _imageService.UploadImageAsync(file);
//                return Ok(new { message = "Upload successful", url = imageUrl });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Cloudinary test failed: {ex.Message}");
//            }
//        }
//    }
//}
