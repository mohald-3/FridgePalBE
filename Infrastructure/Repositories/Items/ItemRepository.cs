using Application.Interfaces.Repositories.Items;
using Domain.Models.Item;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Items
{
    public class ItemRepository : IItemRepository
    {
        private readonly RealDatabase _context;
        public ItemRepository(RealDatabase context) => _context = context;

        public async Task<List<ItemModel>> GetAllAsync()
        {
            return await _context.Items.Include(i => i.Category).ToListAsync();
        }

        public async Task<ItemModel?> GetByIdAsync(Guid id)
        {
            return await _context.Items.Include(i => i.Category).FirstOrDefaultAsync(i => i.ItemId == id);
        }

        public async Task<ItemModel> AddAsync(ItemModel item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ItemModel?> UpdateAsync(Guid id, ItemModel updatedItem)
        {
            var existing = await _context.Items.FindAsync(id);
            if (existing == null) return null;

            existing.ProductName = updatedItem.ProductName;
            existing.Quantity = updatedItem.Quantity;
            existing.ExpirationDate = updatedItem.ExpirationDate;
            existing.CategoryId = updatedItem.CategoryId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return false;

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
