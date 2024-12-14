using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Back.DTO.UsersDTO;
using Back.Models;
namespace Back.DTO;
public static class UserExtensions
{
    public static User ToEntity(this UserDTO userDTO)
    {
        return new User()
        {
            Login = userDTO.email!,
            Password = userDTO.password!
        };
    }
}