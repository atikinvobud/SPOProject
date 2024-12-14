using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.DTO.AccountInfosDTO;
using Back.Models;

namespace Back.DTO;
public static class AccountInfoExtensions
{
    public static AccountInfoDTO ToDTO(this UserInfo userInfo)
    {
        List<string> favouriteSportsList = [];
        foreach (var sport in userInfo.FavouriteSports)
        {
            favouriteSportsList.Add(sport.Name);
        }

        string cityNotNull;
        if (userInfo.CityId != null) cityNotNull = userInfo.City!.Name;
        else cityNotNull = "";

        string descriptionNotNull;
        if (userInfo.Description != null) descriptionNotNull = userInfo.Description;
        else descriptionNotNull = "";

        return new AccountInfoDTO()
        {
            surname = userInfo.Surname,
            name = userInfo.Name,
            gender = userInfo.Gender,
            city = cityNotNull,
            birthday = userInfo.Birthday,
            favouriteSports = favouriteSportsList,
            description = descriptionNotNull
        };
    }

    public static void UpdateEntity(this UserInfo userInfo, AccountInfoIdDTO userInfoDTO)
    {
        userInfo.Name = userInfoDTO.name!;
        userInfo.Surname = userInfoDTO.surname!;
        userInfo.Gender = userInfoDTO.gender!;
        userInfo.Description = userInfoDTO.description!;
        userInfo.CityId = userInfoDTO.cityId!;
        userInfo.Birthday = userInfoDTO.dateOfBirth;
        userInfo.FavouriteSports.Clear();
    }
}