using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.DTO;
using Back.Models;
using Back.DTO.UsersDTO;
using Back.DTO.UserInfosDTO;


namespace Back.Controllers;

[ApiController]
[Route("auth")]
public class AuthorizationController : ControllerBase
{
    private readonly Context context;

    public AuthorizationController(Context context)
    {
        this.context = context;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] UserDTO userDTO)
    {
        User user = userDTO.ToEntity();
        user.RoleId = 1;
        if (context.Users.Where(u => u.Login == user.Login).ToList().Count == 0)
        {
            context.Users.Add(user);
            context.SaveChanges();
            var jsonData =new {id = user.Id };
            return Ok(jsonData);
        }
        else
        {
            return Conflict();
        }
    }
    [HttpPost("set-information")]
    public IActionResult SetInformation([FromBody] UserInfoDTO userInfoDTO)
    {
        UserInfo userInfo = userInfoDTO.ToEntity();
        userInfo.CityId = 1;
        if(context.Users.Where( u => u.Id == userInfo.UserId).ToList().Count ==1)
        {
            context.UserInfos.Add(userInfo);
            context.SaveChanges();
            return StatusCode(201);
        }
        else return NotFound();
    }
    [HttpGet("login")]
    public IActionResult AuthorizeUser([FromBody] UserDTO userDTO)
    {
        var User = context.Users.Where(u => u.Login == userDTO.email).ToList();
        if(User.Count == 1)
        {
            if(User[0].Password == userDTO.password)
            {
                var jsonData = new {id = User[0].Id};
                return Ok(jsonData);
            }
        }
        return NotFound();
    }
}