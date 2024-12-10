using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.TournamentDTOs;

public record ExtendedTournamentDTO
{
    public int? id { get; set; }
    public string? name { get; set; }
    public string? sport { get; set; }
    public string? format { get; set; }
    public string? address { get; set; }
    public string? status { get; set; }
    public string? description { get; set; }
    public string? contacts { get; set; }
    public DateOnly startDate { get; set; }
    public DateOnly endDate { get; set; }
    public DateTime registrationDeadline { get; set; }
}