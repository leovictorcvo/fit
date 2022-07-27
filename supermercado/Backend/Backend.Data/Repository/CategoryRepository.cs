using Backend.Data.Contracts;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SupermarketContext context;

        public CategoryRepository(SupermarketContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => 
            await context.Categories.AsNoTracking().OrderBy(c => c.Name).ToListAsync();

        public async Task<IEnumerable<Product>> GetAllProductsInCategoryAsync(Guid categoryId) =>
            await context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }
}
