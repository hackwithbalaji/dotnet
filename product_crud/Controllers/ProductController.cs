using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_crud.Controllers
{
    [ApiController]
    [Route("demo")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public String Get()
        {
            return "demo";
        }
    }
}
