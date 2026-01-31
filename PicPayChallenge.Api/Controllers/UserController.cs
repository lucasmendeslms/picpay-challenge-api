using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Api.Model.DTOs;

namespace PicPayChallenge.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    [HttpPost ("register")]
    public IActionResult RegisterUser ([FromBody] UserRegisterDto user)
    {
    
        return Created();
    }

// public async Task<> RegisterMerchant◊
}

