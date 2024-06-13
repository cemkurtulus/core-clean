using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    : ControllerBase
{
    [HttpGet(Name = "GetCustomer"), Authorize]
    public async Task<IActionResult> Get(Guid id)
    {
        var customer = await customerService.GetCustomerById(id);
        return Ok(customer);
    }
        
    [HttpPost(Name = "CreateCustomer")]
    public async Task<IActionResult> Post(CreateCustomerApiModel apiModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var customerId = await customerService.CreateCustomer(apiModel);
        return Ok(customerId);
    }
}