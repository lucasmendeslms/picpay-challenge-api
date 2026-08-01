using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Application.Services.Interfaces;

namespace PicPayChallenge.Api.Controllers;

[ApiController]
[Route("/customer")]
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
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                type: $"",
                detail: "Failed to register a customer",
                instance: HttpContext.Request.Path
            );
        }
        
        var result = await _customerService.RegisterAsync(customer);

        return Created();
    }
}