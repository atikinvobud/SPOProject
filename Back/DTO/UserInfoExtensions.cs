using System;
using Back.DTO.UserInfosDTO;
using Back.Models;
namespace Back.DTO;
public static class UserInfoxtensions
{
    public static UserInfo ToEntity(this UserInfoDTO userInfoDTO)
    {
        return new UserInfo()
        {
            UserId = userInfoDTO.id,
            Name =userInfoDTO.name!,
            Surname =userInfoDTO.surname!,
            Description =userInfoDTO.gender!,
            Birthday =userInfoDTO.dateOfBirth
        };
    }
}