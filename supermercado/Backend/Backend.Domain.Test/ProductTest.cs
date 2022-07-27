using Backend.Domain.Exceptions;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Backend.Domain.Test
{
    public class ProductTest
    {
        readonly Product product;
        readonly Category category;
        const string ProductName = "test";
        const int InitialStock = 10;

        public ProductTest()
        {
            category = new Category("test");
            product = new Product(ProductName, InitialStock, category);
        }

        [Fact]
        public void ShouldAutoGenerateId()
        {
            Assert.True(Guid.TryParse(product.Id.ToString(), out _));
            Assert.NotEqual(product.Id, Guid.Empty);
        }

        [Fact]
        public void ShouldAcceptNamePassedOnConstructor()
        {
            Assert.Equal(ProductName, product.Name);
        }

        [Fact]
        public void ShouldAcceptQuantityPassedOnConstructor()
        {
            Assert.Equal(InitialStock, product.QuantityInStock);
        }

        [Fact]
        public void ShouldRemoveQuantityIfStockIsSufficient()
        {
            product.RemoveQuantityFromStock(2);

            Assert.Equal(8, product.QuantityInStock);
        }

        [Fact]
        public void ShouldThrowAnExceptionIfStockIsInsufficient()
        {
            Assert.Throws<InsufficientStockException>(() => product.RemoveQuantityFromStock(12));
        }

    }
}
