namespace Back.Models;

public class Team
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public int TeamsUsersId { get; set;}
    public TeamUsers? TeamUsers { get; set;}
}
