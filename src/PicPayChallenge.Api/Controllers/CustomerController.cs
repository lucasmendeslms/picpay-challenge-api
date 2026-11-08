using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Application.Interfaces.Services;

namespace PicPayChallenge.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    [HttpPost]
    public async Task<IActionResult> Register (
        [FromBody] RegisterCustomerRequest customer)
    {

        var validate = new RegisterCustomerRequestValidator().Validate(customer);

        if (validate.IsValid is false)
        {
            throw new ArgumentException();
        }
        
        var result = await _customerService.RegisterAsync(customer);
        
        return Created();
    }

    [HttpGet("teste")]
    public Task<IActionResult> TestException()
    {
        // Força o estouro da sua exceção customizada para testar a captura no Middleware
        throw new InvalidOperationException("Usuário de teste não foi encontrado no sistema.");
    }
}