using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.Models;

namespace Back.Controllers
{
    [ApiController]
    [Route("Team")]
    public class TeamController : ControllerBase
    {
        private readonly Context context;

        public TeamController(Context context)
        {
            this.context = context;
        }

        [HttpPost("Create")]
        public IActionResult Get()
        {
            
            return Ok();
        }
    }
}