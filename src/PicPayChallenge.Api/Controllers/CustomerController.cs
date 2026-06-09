using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Application.DTOs.Customer;
using PicPayChallenge.Application.DTOs.Customer.Validators;
using PicPayChallenge.Application.Services.Interfaces;

namespace PicPayChallenge.Api.Controllers;

[ApiController]
[Route("/customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    [HttpPost]
    public async Task<IActionResult> Register (
        [FromBody] RegisterCustomerDto customer)
    {

        var validate = new RegisterCustomerDtoValidator().Validate(customer);

        if (validate.IsValid is false)
        {
            var errors = validate.Errors.Select(e => e.ErrorMessage);
            return BadRequest(errors);
        }
        
        var result = await _customerService.RegisterAsync(customer);

        return Created();
    }

}