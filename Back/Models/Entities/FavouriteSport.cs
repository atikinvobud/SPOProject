namespace Back.Models;

public class FavouriteSport
{
    public int Id { get; set;}
    public required string Name { get; set; }
    public string? Description { get; set; }
    public List<UserInfo> UserInfos{ get; set; } =[];

}