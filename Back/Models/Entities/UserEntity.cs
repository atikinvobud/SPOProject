namespace Back.Models;
public class User
{
    public int Id { get; set; }
    public UserInfo? UserInfo{ get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public int RoleId { get; set; }
    public Role? Role{ get; set; }
    public List<TeamUsers> TeamsUsers { get; set; } = [];
}