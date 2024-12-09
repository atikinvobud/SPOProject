using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.DTO;
using Back.Models;
using Microsoft.EntityFrameworkCore;
using Back.DTO.TournamentDTOs;

namespace Back.Controllers;

[ApiController]
[Route("tournaments")]
public class TournamentController : ControllerBase
{
    private readonly Context context;

    public TournamentController(Context context)
    {
        this.context = context;
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] CreateTournamentDTO createTournamentDTO)
    {
        var tournament = createTournamentDTO.ToEntity(context);
        context.Tournaments.Add(tournament);
        context.SaveChanges();
        var jsonData = new {id = tournament.Id};
        return Ok(jsonData);
    }
}