using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Contracts
{
    public interface ICartRepository
    {
        Task<Cart> AddItemToCart(Guid cartId, Guid productId, int quantity);
        Task<Cart> GetCart(Guid cartId);
    }
}
