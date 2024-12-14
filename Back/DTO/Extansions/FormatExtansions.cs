using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models;

namespace Back.DTO.FormatDTOs;

public static class FormatExtansions
{
    public static FormatDTO ToDTO(this Format format)
    {
        return new()
        {
            id = format.Id,
            name = format.Name,
        };
    }
}