using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.DTO;
using Back.Models;
using Back.DTO.UsersDTO;
using Back.DTO.UserInfosDTO;
using Microsoft.EntityFrameworkCore;
using Back.DTO.AccountInfosDTO;

namespace Back.Controllers;

[ApiController]
[Route("personal-account")]
public class PersonalAccountController : ControllerBase
{
    private readonly Context context;

    public PersonalAccountController(Context context)
    {
        this.context = context;
    }

    [HttpGet("{id}")]
    public IActionResult GetInfo([FromRoute] int id)
    {
        UserInfo userInfo = context.UserInfos.Include(ui => ui.City).Include(ui => ui.FavouriteSports).FirstOrDefault(ui => ui.UserId == id)!;
        return Ok(userInfo.ToDTO());
    }

    [HttpPut("edit")]
    public IActionResult ChangeInfo([FromBody] AccountInfoIdDTO userChange)
    {

        UserInfo userInfo = context.UserInfos.Include(u => u.User).Include(u => u.FavouriteSports).First(ui => ui.UserId == userChange.id)!;

        userInfo.UpdateEntity(userChange);

        var newFavouriteSports = context.FavouriteSports.Where(fs => userChange.favouriteSportsId.Contains(fs.Id)).ToList();
        userInfo.FavouriteSports.AddRange(newFavouriteSports);

        context.SaveChanges();
        return Ok();
    }
}