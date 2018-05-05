using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using SportsStoreWebApi.Models;

namespace SportsStoreWebApi.Controllers
{
    public class OrdersController : ApiController
    {
        private IRepository _repository;

        public OrdersController()
        {
            _repository = (IRepository) GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRepository));
        }

        [HttpGet]
        [Authorize(Roles = "Administrators")]
        public IEnumerable<Order> List()
        {
            return _repository.Orders;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                IDictionary<int, Product> products = _repository.Products
                    .Where(p => order.Lines.Any(ol => ol.ProductId == p.Id)).ToDictionary(p => p.Id);

                order.TotalCost = order.Lines.Sum(ol => ol.Count * products[ol.ProductId].Price);

                await _repository.SaveOrderAsync(order);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrators")]
        public async Task DeleteOrder(int id)
        {
            await _repository.DeleteOrderAsync(id);
        }
    }
}
