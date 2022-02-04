using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_store.Core.DTOs;
using online_store.Core.Interfaces;
using online_store.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace online_store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> Get()
        {
            var products = repository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            repository.AddProduct(product);
            return Ok();
        }

        [HttpGet("best")]
        public ActionResult<ProductDTO> GetBestProducts()
        {
            var products = repository.GetBestProducts();
            return Ok(products);
        }

        [HttpGet("searchByName")]
        public ActionResult<List<SearchProductDTO>> GetByName([FromQuery] string name)
        {
            var products = repository.GetProductsByName(name);
            return Ok(products);
        }

        [HttpGet("searchByCategory")]
        public ActionResult<List<SearchProductDTO>> GetByCategory([FromQuery] string category)
        {
            var products = repository.GetProductsByCategory(category);
            return Ok(products);
        }
    }
}
