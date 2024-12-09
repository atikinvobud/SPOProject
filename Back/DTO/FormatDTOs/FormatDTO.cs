using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.FormatDTOs;

public record FormatDTO
{
    public int id { get; set; }
    public string? name { get; set; }
}