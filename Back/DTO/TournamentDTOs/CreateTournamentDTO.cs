using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.TournamentDTOs;

public record CreateTournamentDTO
{
    public string? name { get; set; }
    public int typeOfSport { get; set; }
    public int format { get; set; }
    public string? placement { get; set; }
    public DateOnly startDate  { get; set; }
    public DateOnly endTime  { get; set; }
    public string? description  { get; set; }
    public string? contacts  { get; set; }
    public DateTime registrationDeadline  { get; set; }
}