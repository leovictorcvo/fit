using System;
using System.Collections.Generic;

namespace Backend.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        protected Category() {}

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Products = new List<Product>();
        }
    }
}
