using Backend.Data.Contracts;
using Backend.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Backend.Data.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly SupermarketContext context;

        public CartRepository(SupermarketContext context)
        {
            this.context = context;
        }

        public async Task<Cart> AddItemToCart(Guid cartId, Guid productId, int quantity)
        {
            var cart = await this.context.Carts.FindAsync(cartId);
            if (cart == null)
            {
                cart = new Cart(cartId);
                this.context.Carts.Add(cart);
                await this.context.SaveChangesAsync();
            }
            cart.AddItem(productId, quantity);
            this.context.Carts.Update(cart);
            await this.context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> GetCart(Guid cartId)
        {
            var cart = await this.context.Carts.FindAsync(cartId);
            if (cart == null)
            {
                cart = new Cart(cartId);
                this.context.Carts.Add(cart);
                await this.context.SaveChangesAsync();
            }
            return cart;
        }
    }
}
