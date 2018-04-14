using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsStoreWebApi.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("SportsStoreWebApiDb")
        {
            Database.SetInitializer<ProductDbContext>(new ProductDbInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}