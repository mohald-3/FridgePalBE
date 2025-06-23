using Domain.Models;
using Domain.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            CategoryData(modelBuilder);
            // Add more methods for other entities as needed
        }

        public static void CategoryData(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, CategoryName = "Dairy" },
                new CategoryModel { Id = 2, CategoryName = "Meat" },
                new CategoryModel { Id = 3, CategoryName = "Vegetables" },
                new CategoryModel { Id = 4, CategoryName = "Fruits" },
                new CategoryModel { Id = 5, CategoryName = "Fish" },
                new CategoryModel { Id = 6, CategoryName = "Beverages" },
                new CategoryModel { Id = 7, CategoryName = "Frozen" },
                new CategoryModel { Id = 8, CategoryName = "Other" }
            );
        }

    }
}
