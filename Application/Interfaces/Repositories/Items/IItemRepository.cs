using Domain.Models.Item;

namespace Application.Interfaces.Repositories.Items
{
    public interface IItemRepository
    {
        Task<List<ItemModel>> GetAllAsync();
        Task<ItemModel?> GetByIdAsync(Guid id);
        Task<ItemModel> AddAsync(ItemModel item);
    }
}
