using FitnessClub.Service.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace FitnessClub.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    //register
    //get all users
    //get user info
    //update user info
    //delete user
    //login
    //logout - 

    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        return Ok();
    }
    //crud
    
}