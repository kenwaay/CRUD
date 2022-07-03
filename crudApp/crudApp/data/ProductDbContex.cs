using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace crudApp.data
{
    public class ProductDbContex : DbContext
    {

        public ProductDbContex(DbContextOptions<ProductDbContex> options) : base(options)
        {
            Database.EnsureCreated(); // this make sure that database is created once before we access it
        }
        public DbSet<Product> products { get; set; } // database settings of products

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }

        private Product[] GetProducts() // create sample array with products to database
        {
            return new Product[]
            {
                new Product { ID = 0, Model = "QWERTY", Manufacturer = "cSharp", Category = "Keyboard", Price = 100},
                new Product { ID = 1, Model = "ABCD", Manufacturer = "cSharp", Category = "Keyboard", Price = 120},
                new Product { ID = 2, Model = "ScrollUp", Manufacturer = "MIKI", Category = "Mouse", Price = 60},
                new Product { ID = 3, Model = "BassMarck1942", Manufacturer = "mrSonics", Category = "Headphones", Price = 90},
                new Product { ID = 4, Model = "BassBoomber", Manufacturer = "Filiphs", Category = "Headphones", Price = 190},
                new Product { ID = 5, Model = "LED-1234", Manufacturer = "Zkimssung", Category = "Monitor", Price = 250},
                new Product { ID = 6, Model = "Kine-SCOP", Manufacturer = "Zkimssung", Category = "Monitor", Price = 350},

            };
        }

    }
}
