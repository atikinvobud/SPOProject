using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.Models;
using Back.DTO.SportDTOs;

namespace Back.Controllers
{
    [ApiController]
    [Route("sports")]
    public class SportController : ControllerBase
    {
        private readonly Context context;

        public SportController(Context context)
        {
            this.context = context;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            List<SportDTO> sports = new List<SportDTO>();
            foreach (Sport sport in context.Sports.ToList())
            {
                sports.Add(sport.ToDTO());
            }
            return Ok(sports);
        }
    }
}