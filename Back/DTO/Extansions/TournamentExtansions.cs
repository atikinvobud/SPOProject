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
            End = createTournamentDTO.endDate,
            Registration = createTournamentDTO.registrationDeadline,
        };
        context.Dates.Add(date);

        Location location = new Location()
        {
            CityId = createTournamentDTO.cityId,
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
            Link = "NotALink",
        };
    }

    public static BasedTournamentDTO ToBasedDTO(this Tournament tournament, Context context)
    {
        return new BasedTournamentDTO()
        {
            id = tournament.Id,
            name = tournament.Name,
            sport = context.Sports.Find(tournament.SportId)!.Name,
            format = context.Formats.Find(tournament.FormatId)!.Name,
            city = context.NotACities.Find(context.Locations.Find(tournament.LocationId)!.CityId)!.Name,
            status = "Решим позже",
            startDate = context.Dates.Find(tournament.DateId)!.Start,
            endDate = context.Dates.Find(tournament.DateId)!.End,
            registrationDeadline = context.Dates.Find(tournament.DateId)!.Registration,
        };
    }

    public static ExtendedTournamentDTO ToExtendedDTO(this Tournament tournament, Context context)
    {
        return new ExtendedTournamentDTO()
        {
            id = tournament.Id,
            name = tournament.Name,
            sport = context.Sports.Find(tournament.SportId)!.Name,
            format = context.Formats.Find(tournament.FormatId)!.Name,
            address = context.NotACities.Find(context.Locations.Find(tournament.LocationId)!.CityId)!.Name,
            status = "Решим позже",
            description = tournament.Description,
            contacts = tournament.contacts,
            startDate = context.Dates.Find(tournament.DateId)!.Start,
            endDate = context.Dates.Find(tournament.DateId)!.End,
            registrationDeadline = context.Dates.Find(tournament.DateId)!.Registration,
        };
    }
}