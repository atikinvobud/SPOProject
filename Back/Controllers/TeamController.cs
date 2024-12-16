using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.Models;
using Back.DTO.TeamDTOs;
using Back.DTO.TournamentDTOs;

namespace Back.Controllers
{
    [ApiController]
    [Route("Team")]
    public class TeamController : ControllerBase
    {
        private readonly Context context;

        public TeamController(Context context)
        {
            this.context = context;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateTeamDTO createTeamDTO)
        {
            Team team = createTeamDTO.ToTeamEntity();
            context.Teams.Add(team);
            context.SaveChanges();

            TeamUsers teamUsers = createTeamDTO.ToTeamUsersEntity(context, team.Id);
            teamUsers.Users.Add(context.Users.Find(createTeamDTO.creatorId)!);

            context.TeamsUsers.Add(teamUsers);
            context.SaveChanges();
            return Ok();
        }
    }
}