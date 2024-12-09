using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.SportDTOs;

public record SportDTO
{
    public int id { get; set; }
    public string? name { get; set; }
}