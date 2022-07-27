using Backend.Domain.Models;
using System;
using Xunit;

namespace Backend.Domain.Test
{
    public class CategoryTest
    {
        readonly Category category;
        const string CategoryName = "test";

        public CategoryTest()
        {
            category = new Category(CategoryName);
        }

        [Fact]
        public void ShouldAutoGenerateId()
        {
            Assert.True(Guid.TryParse(category.Id.ToString(), out _));
            Assert.NotEqual(category.Id, Guid.Empty);
        }

        [Fact]
        public void ShouldAcceptNamePassedOnConstructor()
        {
            Assert.Equal(CategoryName, category.Name);
        }
    }
}
