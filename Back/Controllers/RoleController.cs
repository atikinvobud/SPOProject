using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Back.Models;
using Back.DTO.RoleDTOs;
using Back.Migrations;

namespace Back.Controllers
{
    [ApiController]
    [Route("role")]
    public class RoleController : ControllerBase
    {
        private readonly Context context;

        public RoleController(Context context)
        {
            this.context = context;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateRoleDTO createRoleDTO)
        {
            Role role = createRoleDTO.ToEntity();
            context.Roles.Add(role);
            context.SaveChanges();
            return Ok();
        }
    }
}