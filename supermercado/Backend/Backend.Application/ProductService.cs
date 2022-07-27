using Backend.Application.Contracts;
using Backend.Data.Contracts;
using Backend.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Backend.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Product> GetAsync(Guid id) => 
            await repository.GetAsync(id);

        public async Task RemoveProductFromStock(Guid productId, int quantity)
        {
            var product = await repository.GetAsync(productId);
            if (product == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }
            product.RemoveQuantityFromStock(quantity);
            await repository.UpdateAsync(product);
        }
    }
}
