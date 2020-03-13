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
    public class CustomersController : ControllerBase
    {
        private CustomerService _customerService;

        public CustomersController()
        {
            _customerService = new CustomerService();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Get()
        {
            return _customerService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> Get(int id)
        {
            return _customerService.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<int> Post([FromBody] CustomerDto customerDto)
        {
            return _customerService.Add(customerDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] CustomerDto customerDto)
        {
            return _customerService.Update(customerDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return _customerService.Delete(id);
        }
    }
}
