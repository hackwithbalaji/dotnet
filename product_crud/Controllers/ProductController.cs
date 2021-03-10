using Microsoft.AspNetCore.Mvc;
using product_crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_crud.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {   
        public readonly ApplicationDbContext _ctx;

        public ProductController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _ctx.products.Select(s => s).ToList();
        }

        [HttpGet("productByName")]
        public IEnumerable<Product> GetByName(String name)
        {
            return _ctx.products.Where(s => s.Name == name);
        }

        [HttpPost]
        public void Post(Product product)
        {
            _ctx.products.Add(product);
            _ctx.SaveChanges();
        }
    }
}
