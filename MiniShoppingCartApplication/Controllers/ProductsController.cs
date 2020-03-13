using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniShoppingCartApplication.Services;
using MiniShoppingCartApplication.ViewModels;

namespace MiniShoppingCartApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return _productService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            return _productService.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<int> Post()
        {
            ProductDto product = new ProductDto();
            product.Name = HttpContext.Request.Form["Name"];
            product.Description = HttpContext.Request.Form["Description"];
            product.Price = decimal.Parse(HttpContext.Request.Form["Price"]);
            product.Quantity = int.Parse(HttpContext.Request.Form["Quantity"]);
            var files = Request.Form.Files.Count() > 0 ? Request.Form.Files.ToList() : null;
            return _productService.Add(product, files);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id)
        {
            ProductDto product = new ProductDto();
            product.Name = HttpContext.Request.Form["Name"];
            product.Description = HttpContext.Request.Form["Description"];
            product.Price = decimal.Parse(HttpContext.Request.Form["Price"]);
            product.Quantity = int.Parse(HttpContext.Request.Form["Quantity"]);
            product.ProductID = id;
            var files = Request.Form.Files.Count() > 0 ? Request.Form.Files.ToList() : null;
            return _productService.Update(product, files);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return _productService.Delete(id);
        }
    }
}
