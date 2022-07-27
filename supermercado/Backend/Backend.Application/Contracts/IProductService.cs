using Backend.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Backend.Application.Contracts
{
    public interface IProductService
    {
        Task<Product> GetAsync(Guid id);
        Task RemoveProductFromStock(Guid productId, int quantity);
    }
}
