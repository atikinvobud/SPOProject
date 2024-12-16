namespace Back.Models;

public class TeamUsers
{
    public int Id { get; set; }
    public List<Request> Requests { get; set; }=[];
    public List<User> Users{ get; set; } =[];
    public int TeamId { get; set; }
    public Team? Team { get; set; }
    public required DateOnly DateOfRegistration{ get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; }
}