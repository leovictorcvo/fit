using Backend.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Backend.Application.Contracts
{
    public interface ICartService
    {
        Task<Cart> GetCart(Guid cartId);
        Task<Cart> AddItemToCart(Guid cartId, Guid productId, int quantity);
    }
}
