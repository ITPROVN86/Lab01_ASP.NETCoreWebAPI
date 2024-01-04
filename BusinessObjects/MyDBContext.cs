using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class MyDBContext: DbContext
    {
        public MyDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot root = builder.Build();
            optionsBuilder.UseSqlServer(root.GetConnectionString("MyStoreDB"));
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId =1, CategoryName="Tivi"},
                new Category { CategoryId = 2, CategoryName = "Laptop" },
                new Category { CategoryId = 3, CategoryName = "Bàn phím" },
                new Category { CategoryId = 4, CategoryName = "Chuột" },
                new Category { CategoryId = 5, CategoryName = "Ram" });
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId=1, ProductName="Samsung 32 inch",CategoryId=1,UnitsInStock=100,UnitPrice=15000000M},
                new Product { ProductId = 2, ProductName = "Samsung 43 inch", CategoryId = 1, UnitsInStock = 150, UnitPrice = 19000000M },
                new Product { ProductId = 3, ProductName = "Acer 5750", CategoryId = 2, UnitsInStock = 50, UnitPrice = 50000000M },
                new Product { ProductId = 4, ProductName = "Dell 3215", CategoryId = 2, UnitsInStock = 100, UnitPrice = 5000000M },
                new Product { ProductId = 5, ProductName = "Asus 1200", CategoryId = 2, UnitsInStock = 100, UnitPrice = 3000000M },
                new Product { ProductId = 6, ProductName = "Logitech Optical", CategoryId =3, UnitsInStock = 1000, UnitPrice = 400000M }
                );
        }

    }
}
