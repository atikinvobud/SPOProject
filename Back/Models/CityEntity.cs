namespace Back.Models;

public class City
{
    public int Id { get; set;}
    public required string Name { get; set; }
    public List<UserInfo> UserInfos{ get; set; } = [];
    public List<Location> Locations{ get; set; } = [];
}