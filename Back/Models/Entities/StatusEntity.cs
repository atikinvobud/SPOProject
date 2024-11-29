namespace Back.Models;

public class Status
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public List<Request> Requests{ get; set; }=[];
}
