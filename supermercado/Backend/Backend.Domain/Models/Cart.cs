using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Domain.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public List<CartItem> Items { get; set; }

        protected Cart()
        {
            Items = new List<CartItem>();
        }

        public Cart(Guid id):this()
        {
            this.Id = id;
        }

        public void AddItem(Guid productId, int quantity)
        {
            var item = Items.SingleOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                item = new CartItem(Guid.NewGuid(), this.Id, productId, quantity);
                Items.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
        }
    }
}
