namespace Back.Models;
public class Role
{
    public int Id { get; set; }
    public required string Name{ get; set; }
    public string? Description { get; set; }
    public required bool IsTeamRole{ get; set; }
    public List<User> Users { get; set; } =[];
    public List<TeamUsers> TeamsUsers{ get; set; } =[];
    
}