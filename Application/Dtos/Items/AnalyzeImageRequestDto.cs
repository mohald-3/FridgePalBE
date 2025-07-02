using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Items
{
    public class AnalyzeImageRequestDto
    {
        public IFormFile Image { get; set; }
    }
}
