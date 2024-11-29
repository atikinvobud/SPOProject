namespace Back.Models;

public class City
{
    public int Id { get; set;}
    public required string Name { get; set; }
<<<<<<< HEAD:Back/Models/CityEntity.cs
    public List<UserInfo> UserInfos{ get; set; } = [];
=======
    public List<UserInfo> UserInfos{ get; set; } =[];
    public List<Location> Locations { get; set; } =[];
>>>>>>> e849b02351b97ec4425187c5143ec42a36389f3a:Back/Models/Entities/CityEntity.cs
}