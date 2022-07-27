using Backend.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Backend.Data.Contracts
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(Guid id);
        Task UpdateAsync(Product product);
    }
}
