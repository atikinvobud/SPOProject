using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.TeamDTOs;

public record CreateTeamDTO
{
    public int creatorId { get; set; }
    public string? name { get; set; }
}