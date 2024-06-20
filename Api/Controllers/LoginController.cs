using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController(ILogger<CustomerController> logger, IAuthService authService) : ControllerBase
{
    [HttpPost(Name = "LoginCustomer")]
    public async Task<IActionResult> Login(LoginRequestApiModel loginModel)
    {
        logger.LogWarning("Hello from LoginController");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var loginCustomer = await authService.LoginUser(loginModel);
        return Ok(loginCustomer);
    }
}