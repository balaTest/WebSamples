using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWebAPI.Controllers
{
    using HelloWebAPI.Models;
    public class ProductsController : ApiController
    {

        Product[] products = new Product[] 
    { 
        new Product { Id = 1, Name = "Tomato soup", Category = "Groceries", Price = 1.39M }, 
        new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
        new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
    };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return product;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where(
                (p) => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }
    }
}
