using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.RoleDTOs;

public record CreateRoleDTO
{
    public int id { get; set; }
    public string? name { get; set; }
    public bool isTeamRole { get; set; }
}