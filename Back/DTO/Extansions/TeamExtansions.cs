using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models;


namespace Back.DTO.TeamDTOs;

public static class TeamExtansions
{
    public static Team ToTeamEntity(this CreateTeamDTO createTeamDTO)
    {
        return new()
        {
            Name = createTeamDTO.name!
        };
    }

    public static TeamUsers ToTeamUsersEntity(this CreateTeamDTO createTeamDTO, Context context, int teamId)
    {
        return new()
        {
            Id = createTeamDTO.creatorId,
            RoleId = 2,
            TeamId = teamId,
            DateOfRegistration = DateOnly.FromDateTime(DateTime.Now)
        };
    }
}