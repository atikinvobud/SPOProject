using System;
namespace Back.DTO.AccountInfosDTO;
public record AccountInfoIdDTO
{
    public int id { get; set; }
    public string? surname { get; set; }
    public string? name { get; set; }
    public string? gender { get; set; }
    public string? description { get; set; }
    public int cityId { get; set; }
    public DateOnly dateOfBirth{ get; set; }
    public List<int> favouriteSportsId { get; set; } = [];
}