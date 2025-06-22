using Domain.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Item
{
    public class ItemModel
    {
        [Key]
        public Guid ItemId { get; set; }

        //public Guid UserId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime ExpirationDate { get; set; }

        public bool Notified { get; set; } = false;

        public int CategoryId { get; set; }

        // Optional: Navigation property

        //public User? User { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
