using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Api.Model.DTOs;

namespace PicPayChallenge.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    [HttpPost ("individual")]
    public IActionResult RegisterIndividual ([FromBody] IndividualUserDto individualUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        return Created();
    }

    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    [HttpPost("company")]
    public IActionResult RegisterCompany([FromBody] CompanyUserDto companyUser)
    {
        return Created();
    }

// public async Task<> RegisterMerchant◊
}

