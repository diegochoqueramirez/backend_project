using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_store.Core.Interfaces;
using online_store.Core.Models;
using System.Collections.Generic;

namespace online_store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository repository;

        public CategoryController(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = repository.GetAll();
            return Ok(categories);
        }
    }
}
