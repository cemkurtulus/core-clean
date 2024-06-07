using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger = logger;

        [HttpGet(Name = "GetCustomer")]
        public CustomerModel Get()
        {
            return customerService.GetCustomerById(Guid.Parse("be7527fa-37a1-49c9-8f4d-5acf5271c1f3"));
        }
    }
}
