using Backend.Data.Contracts;
using Backend.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Backend.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SupermarketContext context;

        public ProductRepository(SupermarketContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetAsync(Guid id) => await context.Products.FindAsync(id);

        public async Task UpdateAsync(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
