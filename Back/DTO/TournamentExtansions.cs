using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.DTO.TournamentDTOs;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.DTO;

public static class TournamentExtansions
{
    public static Tournament ToEntity(this CreateTournamentDTO createTournamentDTO, Context context)
    {
        Date date = new Date()
        {
            Start = createTournamentDTO.startDate,
            End = createTournamentDTO.endTime,
            Registration = createTournamentDTO.registrationDeadline,
        };
        context.Dates.Add(date);

        Location location = new Location()
        {
            CityId = 1,
            Street = "",
            SportObjectName = createTournamentDTO.placement!,
        };
        context.Locations.Add(location);
        context.SaveChanges();

        return new Tournament()
        {
            Name = createTournamentDTO.name!,
            Description = createTournamentDTO.description!,
            DateId = date.Id,
            LocationId = location.Id,
            IsPrivate = false,
            SportId = createTournamentDTO.typeOfSport,
            FormatId = createTournamentDTO.format,
            contacts = createTournamentDTO.contacts,
            NotificationId = 1,
            Link = "NotALink",
        };
    }
}