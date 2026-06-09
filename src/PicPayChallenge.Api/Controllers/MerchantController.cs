using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Application.DTOs;

namespace PicPayChallenge.Api.Controllers;

[ApiController]
[Route("merchant")]
public class MerchantController : ControllerBase
{
    // [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    // [HttpPost("company")]
    // public IActionResult RegisterMerchant([FromBody] MerchantDto merchant)
    // {
    //     return Created();
    // }
}

