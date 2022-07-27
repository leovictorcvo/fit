using Backend.Domain.Models;
using System;

namespace Backend.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ProductDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            QuantityInStock = product.QuantityInStock;
            CategoryId = product.CategoryId;
            CategoryName = product.Category?.Name;
        }
    }
}
