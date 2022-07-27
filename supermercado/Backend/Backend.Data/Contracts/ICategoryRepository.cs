using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Data.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllProductsInCategoryAsync(Guid categoryId);
    }
}
