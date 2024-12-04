using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.DTO;
using Back.DTO.UsersDTO;
using Back.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("Authorization")]
public class AuthorizationController : ControllerBase
{
    private readonly Context context;

    public AuthorizationController(Context context)
    {
        this.context = context;
    }

    [HttpPost("Register")]
    public IActionResult Register([FromBody] UserDTO userDTO)
    {
        User user = userDTO.ToEntity();
        user.RoleId = 1;
        if (context.Users.Where(u => u.Login == user.Login).ToList().Count == 0)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return Ok(user.Id);
        }
        else
        {
            return Conflict();
        }
    }
}