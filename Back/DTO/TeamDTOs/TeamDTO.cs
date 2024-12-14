using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.TeamDTOs;

public record TeamDTO
{
    public string? name { get; set; }
    public int sportId { get; set; }
    
}