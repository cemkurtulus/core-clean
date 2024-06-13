using Core.Interfaces;
using Dto.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    : ControllerBase
{
    private readonly ILogger<CustomerController> _logger = logger;

    [HttpGet(Name = "GetCustomer")]
    public async Task<IActionResult> Get(Guid id)
    {
        var customer = await customerService.GetCustomerById(id);
        return Ok(customer);
    }
        
    [HttpPost(Name = "CreateCustomer")]
    public async Task<IActionResult> Post(CreateCustomerModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var customerId = await customerService.CreateCustomer(model);
        return Ok(customerId);
    }
}