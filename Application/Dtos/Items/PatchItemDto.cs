using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Items
{
    public class PatchItemDto
    {
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? CategoryId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
