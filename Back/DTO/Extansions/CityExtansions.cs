using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models;

namespace Back.DTO.CityDTOs;

public static class CityExtansions
{
    public static CityDTO ToDTO(this City city)
    {
        return new()
        {
            id = city.Id,
            name = city.Name,
        };
    }

    public static City ToEntity(this CreateCityDTO createCityDTO)
    {
        return new()
        {
            Name = createCityDTO.name!,
        };
    }
}