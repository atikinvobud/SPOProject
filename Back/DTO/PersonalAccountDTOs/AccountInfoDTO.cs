using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.AccountInfosDTO;

public record AccountInfoDTO
{
    public string? name { get; set; }
    public string? surname { get; set; }
    public string? gender { get; set; }
    public string? city { get; set; }
    public DateOnly birthday { get; set; }
    public List<string> favouriteSports { get; set; } = [];
}