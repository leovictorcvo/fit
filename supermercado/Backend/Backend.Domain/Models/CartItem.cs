using System;

namespace Backend.Domain.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        protected CartItem() {}

        public CartItem(Guid id, Guid cartId, Guid productId, int quantity)
        {
            Id = id;
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
