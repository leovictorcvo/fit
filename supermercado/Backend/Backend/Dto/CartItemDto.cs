using Backend.Domain.Models;
using System;

namespace Backend.Dto
{
    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public CartItemDto(CartItem item)
        {
            this.ProductId = item.Product.Id;
            this.ProductName = item.Product.Name;
            this.Quantity = item.Quantity;
        }
    }
}
