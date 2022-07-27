using Backend.Application.Contracts;
using Backend.Data.Contracts;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => 
            await repository.GetAllAsync();

        public async Task<IEnumerable<Product>> GetAllProductsInCategoryAsync(Guid categoryId) => 
            await repository.GetAllProductsInCategoryAsync(categoryId);
    }
}
