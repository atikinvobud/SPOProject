using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.UsersDTO;

public record UserDTO
{
    public string? email { get; set; }
    public string? password { get; set; }
}