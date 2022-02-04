using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_store.Core.DTOs;
using online_store.Core.Interfaces;
using System.Collections.Generic;

namespace online_store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerRepository repository;

        public CostumerController(ICostumerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("best")]
        public ActionResult<List<CostumerDTO>> GetBestCostumers()
        {
            var costumers =  repository.GetBestCoatumers();
            return Ok(costumers);
        }

        [HttpGet("searchByProduct")]
        public ActionResult<List<SearchCostumerDTO>> GetCostumersByProduct([FromQuery] string product)
        {
            var products = repository.GetCostumersByProduct(product);
            return Ok(products);
        }
    }
}
