namespace Back.Models;

public class Sport
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public string? Description { get; set;}
    public List<Tournament> Tournaments { get; set; } =[];
}