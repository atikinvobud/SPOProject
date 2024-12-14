using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.DTO;
using Back.Models;
using Microsoft.EntityFrameworkCore;
using Back.DTO.TournamentDTOs;
using System.Runtime.CompilerServices;

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

    private string GetStatus(Tournament tournament)
    {
        DateTime timeNow = DateTime.Now;
        DateOnly dateNow = DateOnly.FromDateTime(timeNow);
        //DateTime tournamentEnd = tournament.Date!.End.ToDateTime();
        if (tournament.Date!.End < dateNow) return "ended";
        if (tournament.Date!.Registration > timeNow) return "registration";
        if (tournament.Date!.Start <= dateNow && tournament.Date!.End >= dateNow) return "active";
        if (tournament.Date!.Registration <= timeNow && tournament!.Date.Start >= dateNow) return "registrationclosed";
        return "undefined";
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
    
    [HttpGet("get")]
    public IActionResult Get([FromQuery] string? name, [FromQuery] int? sportId, [FromQuery] int? cityId, [FromQuery] string? status, [FromQuery] bool? isPrivate)
    {
        List<Tournament> tournaments = context.Tournaments.Include(t => t.Location).Include(t => t.Date).ToList();
        
        if (name != null)
        {
            tournaments = tournaments.Where(t => t.Name.ToLower().Contains(name.ToLower())).ToList();
            tournaments = tournaments.OrderBy(t => t.Name.Length - name.Length).ToList();
        }
        if (sportId != null) tournaments = tournaments.Where(t => t.SportId == sportId).ToList();
        if (cityId != null) tournaments = tournaments.Where(t => t.Location!.CityId == cityId).ToList();
        if (status != null) tournaments = tournaments.Where(t => GetStatus(t) == status).ToList();
        if (isPrivate != null) tournaments = tournaments.Where(t => t.IsPrivate == isPrivate).ToList();

        List<BasedTournamentDTO> tournamentDTOs = new List<BasedTournamentDTO>();
        foreach (Tournament tournament in tournaments)
        {
            tournamentDTOs.Add(tournament.ToBasedDTO(context));
        }
        return Ok(tournamentDTOs);
    }

    [HttpGet("get/{id}")]
    public IActionResult GetId([FromRoute] int id)
    {
        return Ok(context.Tournaments.Find(id)!.ToExtendedDTO(context));
    }
}