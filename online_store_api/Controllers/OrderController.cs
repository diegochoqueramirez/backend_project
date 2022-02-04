using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_store.Core.Interfaces;
using online_store.Core.Models;
using System.Collections.Generic;

namespace online_store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository repository;

        public OrderController(IOrderRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            var orders = repository.GetAll();
            return Ok(orders);
        }
    }
}
