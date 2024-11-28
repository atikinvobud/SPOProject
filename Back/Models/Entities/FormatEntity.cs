namespace Back.Models;
public class Format
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Structure { get; set; }
    public List<Tournament> Tournaments { get; set;} =[];

}