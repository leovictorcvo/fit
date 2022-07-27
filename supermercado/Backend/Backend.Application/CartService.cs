using Backend.Application.Contracts;
using Backend.Data.Contracts;
using Backend.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Backend.Application
{
    public class CartService : ICartService
    {
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;

        public CartService(IProductRepository productRepository, ICartRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        public async Task<Cart> AddItemToCart(Guid cartId, Guid productId, int quantity)
        {
            var productDb = await this.productRepository.GetAsync(productId);
            if (productDb == null)
                throw new ArgumentException("Produto não cadastrado");
            productDb.RemoveQuantityFromStock(quantity);
            await this.productRepository.UpdateAsync(productDb);
            return await this.cartRepository.AddItemToCart(cartId, productDb.Id, quantity);
        }

        public async Task<Cart> GetCart(Guid cartId) =>
            await this.cartRepository.GetCart(cartId);
    }
}
