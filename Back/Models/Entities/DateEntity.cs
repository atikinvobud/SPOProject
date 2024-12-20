namespace Back.Models;

public class Date
{
    public int Id { get; set; }
    public required DateOnly Start { get; set; }
    public required DateOnly End { get; set; }
    public required DateTime Registration  { get; set; }
    public Tournament? Tournament{get; set;}
}