using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.Models;
using Back.DTO.CityDTOs;
using Back.Migrations;

namespace Back.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CityController : ControllerBase
    {
        private readonly Context context;

        public CityController(Context context)
        {
            this.context = context;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            List<CityDTO> cities = new List<CityDTO>();
            foreach (City city in context.NotACities.ToList())
            {
                cities.Add(city.ToDTO());
            }
            return Ok(cities);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateCityDTO createCityDTO)
        {
            City city = createCityDTO.ToEntity();
            context.NotACities.Add(city);
            context.SaveChanges();
            var jsonData = new {id = city.Id};
            return Ok(jsonData);
        }
    }
}