using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.CityDTOs;

public record CityDTO
{
    public int id { get; set; }
    public string? name { get; set; }
}