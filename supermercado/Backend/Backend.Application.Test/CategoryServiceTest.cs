using Backend.Data.Contracts;
using Backend.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Application.Test
{
    public class CategoryServiceTest
    {
        private readonly Mock<ICategoryRepository> mockCategoryRepository;
        private readonly IEnumerable<Category> categories;
        private readonly IEnumerable<Product> foodProducts;
        
        public CategoryServiceTest()
        {
            mockCategoryRepository = new Mock<ICategoryRepository>();
            var foodCategory = new Category("alimentos");
            var drinkCategory = new Category("bebidas");

            var rice = new Product("Arroz", 1, foodCategory);
            var bean = new Product("Feijão", 2, foodCategory);
            var orange = new Product("Laranja", 1, foodCategory);

            categories = new List<Category>() { foodCategory, drinkCategory };
            foodProducts = new List<Product>() { rice, bean, orange };
        }

        [Fact]
        public async Task ShouldReturnAllCategories()
        {
            mockCategoryRepository.Setup(p => p.GetAllAsync()).Returns(Task.FromResult(categories));
            var service = new CategoryService(mockCategoryRepository.Object);

            var result = await service.GetAllAsync();

            Assert.Equal(categories.Count(), result.Count());
        }

        [Fact]
        public async Task ShouldReturnAllProductsFromCategory()
        {
            mockCategoryRepository.Setup(p => p.GetAllProductsInCategoryAsync(It.IsAny<Guid>())).Returns(Task.FromResult(foodProducts));
            var service = new CategoryService(mockCategoryRepository.Object);

            var result = await service.GetAllProductsInCategoryAsync(Guid.NewGuid());

            Assert.Equal(foodProducts.Count(), result.Count());
        }
    }
}
