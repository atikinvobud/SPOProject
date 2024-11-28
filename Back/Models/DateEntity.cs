namespace Back.Models;

public class Date
{
    public int Id { get; set; }
    public required DateOnly Start { get; set; }
    public required DateOnly End { get; set; }
}