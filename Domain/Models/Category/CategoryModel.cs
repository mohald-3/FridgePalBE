using Domain.Models.Item;

namespace Domain.Models.Category
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;

        public ICollection<ItemModel>? Items { get; set; } // will be userful for reverse navigation later on
    }
}
