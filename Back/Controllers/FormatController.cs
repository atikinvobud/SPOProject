using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.Models;
using Back.DTO.FormatDTOs;

namespace Back.Controllers
{
    [ApiController]
    [Route("formats")]
    public class FormatController : ControllerBase
    {
        private readonly Context context;

        public FormatController(Context context)
        {
            this.context = context;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            List<FormatDTO> formats = new List<FormatDTO>();
            foreach (Format format in context.Formats.ToList())
            {
                formats.Add(format.ToDTO());
            }
            return Ok(formats);
        }
    }
}