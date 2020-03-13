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
    public class CustomerOrdersController : ControllerBase
    {
        private CustomerOrderService _customerOrderService;

        public CustomerOrdersController()
        {
            _customerOrderService = new CustomerOrderService();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CustomerOrderDto>> Get()
        {
            return _customerOrderService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<CustomerOrderDto> Get(int id)
        {
            return _customerOrderService.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<int> Post([FromBody] CustomerOrderDto customerOrderDto)
        {
            return _customerOrderService.Add(customerOrderDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] CustomerOrderDto customerOrderDto)
        {
            return _customerOrderService.Update(customerOrderDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return _customerOrderService.Delete(id);
        }
    }
}
