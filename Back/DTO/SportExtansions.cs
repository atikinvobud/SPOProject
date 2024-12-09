using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models;


namespace Back.DTO.SportDTOs;

public static class SportExtansions
{
    public static SportDTO ToDTO(this Sport sport)
    {
        return new()
        {
            id = sport.Id,
            name = sport.Name,
        };
    }
}