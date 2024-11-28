namespace Back.Models;

public class Notification
{
    public int Id { get; set;}
    public required string Text { get; set;}
    public required DateOnly DateOfSending { get; set;}
    public Tournament? Tournament { get; set;}
}