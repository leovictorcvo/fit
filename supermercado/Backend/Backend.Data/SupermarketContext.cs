using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend.Data
{
    public class SupermarketContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; } 

        public SupermarketContext(DbContextOptions options) : base(options)
        {
            AdicionarDadosTeste();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CartItem>().Property(e => e.Id).ValueGeneratedNever();
        }

        private void AdicionarDadosTeste()
        {
            var foodCategory = new Category("Alimentos");
            var drinkCategory = new Category("Bebidas");
            var categories = new Category[] { foodCategory, drinkCategory };

            var rice = new Product("Arroz", GerarEstoque(), foodCategory);
            var olive = new Product("Azeitona", GerarEstoque(), foodCategory);
            var sugar = new Product("Açucar", GerarEstoque(), foodCategory);
            var coffe = new Product("Café", GerarEstoque(), foodCategory);
            var tea = new Product("Chá", GerarEstoque(), foodCategory);
            var coke = new Product("Coca-Cola", GerarEstoque(), drinkCategory);
            var beer = new Product("Cerveja", GerarEstoque(), drinkCategory);
            var products = new Product[] { rice, olive, sugar, coffe, tea, coke, beer };

            Categories.AddRange(categories);
            Products.AddRange(products);
            SaveChanges();
        }

        private int GerarEstoque() => new Random().Next(0, 100);
    }
}
