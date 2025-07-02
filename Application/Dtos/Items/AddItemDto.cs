using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Items
{
    public class AddItemDto
    {
        public string ItemName { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Category { get; set; }
        public IFormFile? Image { get; set; }
    }
}
