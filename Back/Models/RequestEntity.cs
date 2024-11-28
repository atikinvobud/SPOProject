namespace Back.Models;
public class Request
{
    public int Id { get; set;}
    public Tournament? Tournament{get; set;}
    public int StatusId { get; set;}
    public Status? Status { get; set;}
    public required DateOnly Date{ get; set;}
    public int TeamUsersId { get; set;}
    public TeamUsers? TeamUsers{ get; set;}
}