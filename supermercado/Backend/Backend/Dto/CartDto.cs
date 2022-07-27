using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Dto
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public List<CartItemDto> Items { get; set; }

        public CartDto(Cart cart)
        {
            this.Id = cart.Id;
            this.Items = cart.Items.Select(i => new CartItemDto(i)).ToList();
        }
    }
}
