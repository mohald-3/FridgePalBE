using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Items
{
    public class ItemDto
    {
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CategoryId { get; set; }

        public IFormFile? Image { get; set; } // for the uploaded image
    }
}
