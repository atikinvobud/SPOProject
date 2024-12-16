using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models;

namespace Back.DTO.RoleDTOs;

public static class RoleExtansions
{
    public static Role ToEntity(this CreateRoleDTO createRoleDTO)
    {
        return new()
        {
            Name = createRoleDTO.name!,
            IsTeamRole = createRoleDTO.isTeamRole
        };
    }
}