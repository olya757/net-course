using FitnessClub.BL.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthProvider _authProvider;

    public AuthController(IAuthProvider authProvider)
    {
        _authProvider = authProvider;
    }

    [HttpGet]
    [Route("login")] //.../auth/login
    public async Task<IActionResult> LoginUser([FromQuery] string email, [FromQuery] string password)
    {
        try
        {
            var tokens = await _authProvider.AuthorizeUser(email, password);

            return Ok(tokens);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser(string email, string password)
    {
        return Ok();
    }
}