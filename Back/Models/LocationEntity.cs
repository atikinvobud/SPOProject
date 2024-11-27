namespace Back.Models;

public class Location
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
    public required string Street { get; set; }
    public required string SportObjectName { get; set; }
    public List<Tournament> Tournaments { get; set; } =[];
} 