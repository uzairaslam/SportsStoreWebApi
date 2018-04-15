using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SportsStoreWebApi.Models
{
    public class ProductRepository : IRepository
    {
        private readonly ProductDbContext _db = new ProductDbContext();

        public IEnumerable<Product> Products => _db.Products;

        public async Task<int> SaveProductAsync(Product product)
        {
            if (product.Id == 0)
            {
                _db.Products.Add(product);
            }
            else
            {
                Product dbEntry = _db.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Category = product.Category;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                }
            }
            return await _db.SaveChangesAsync();
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            Product dbEntry = _db.Products.Find(productId);
            if (dbEntry != null)
            {
                _db.Products.Remove(dbEntry);
            }
            await _db.SaveChangesAsync();
            return dbEntry;
        }

        public IEnumerable<Order> Orders => _db.Orders;
        public async Task<int> SaveOrderAsync(Order order)
        {
            if (order.Id == 0)
            {
                _db.Orders.Add(order);
            }
            return await _db.SaveChangesAsync();
        }

        public async Task<Order> DeleteOrderAsync(int orderId)
        {
            Order dbEntry = _db.Orders.Find(orderId);
            if (dbEntry != null)
            {
                _db.Orders.Remove(dbEntry);
            }
            await _db.SaveChangesAsync();
            return dbEntry;
        }
    }
}