using System.ComponentModel.DataAnnotations;

namespace Back.Models;

public class UserInfo
{
    public int UserId {get; set; }
    public User? User{ get; set; }
    public required string Name { get; set; }
    public required string Surname{ get; set; }
    public required DateOnly Birthday{ get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
    public List<FavouriteSport> FavouriteSports{ get; set; } = [];
    public string? Description { get; set; }
    public required string? Gender { get; set; }
}