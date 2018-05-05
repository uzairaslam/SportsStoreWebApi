using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using SportsStoreWebApi.Models;

namespace SportsStoreWebApi.Infrastructure
{
    public class CustomResolver : IDependencyResolver, IDependencyScope
    {
        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return serviceType == typeof(IRepository) ? new ProductRepository() : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<Object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}