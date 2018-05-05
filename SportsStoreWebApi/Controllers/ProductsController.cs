using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using SportsStoreWebApi.Models;

namespace SportsStoreWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private IRepository _repository;

        public ProductsController()
        {
            _repository =
                (IRepository) GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRepository));
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repository.Products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.Id == id);
            return product == null ? (IHttpActionResult) BadRequest("No Product Found") : Ok(product);
        }

        [Authorize(Roles = "Administrators")]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _repository.SaveProductAsync(product);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Administrators")]
        public async Task DeleteProduct(int id)
        {
            await _repository.DeleteProductAsync(id);
        }
    }
}
