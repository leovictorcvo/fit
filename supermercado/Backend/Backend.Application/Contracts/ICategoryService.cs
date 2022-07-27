using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllProductsInCategoryAsync(Guid categoryId);
    }
}
