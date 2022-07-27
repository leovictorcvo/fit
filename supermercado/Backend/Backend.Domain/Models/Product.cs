using Backend.Domain.Exceptions;
using System;

namespace Backend.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; } 
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        protected Product() { }
        public Product(string name, int quantity, Category category)
        {
            Id = Guid.NewGuid();
            Name = name;
            QuantityInStock = quantity;
            CategoryId = category.Id;
            Category = category;
        }

        public void RemoveQuantityFromStock(int quantity)
        {
            if (quantity > QuantityInStock)
                throw new InsufficientStockException($"O produto {Name} não tem estoque suficiente para atender esse pedido");
            QuantityInStock -= quantity;
        }
    }
}
