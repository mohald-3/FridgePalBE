using Domain.Models.Item;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class EntityRelationships
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>()
                .HasKey(i => i.ItemId);

            modelBuilder.Entity<ItemModel>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}