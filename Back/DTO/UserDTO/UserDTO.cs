using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.UserDTOs;

public record UserDTO
{
    string? login;
    string? password;
}