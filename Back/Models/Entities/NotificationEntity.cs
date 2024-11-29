namespace Back.Models;

public class Notification
{
    public int Id { get; set;}
    public required string Text { get; set;}
    public required DateOnly DateOfSending { get; set;}
<<<<<<< HEAD:Back/Models/NotificationEntity.cs
=======
    public Tournament? Tournament { get; set;}
>>>>>>> e849b02351b97ec4425187c5143ec42a36389f3a:Back/Models/Entities/NotificationEntity.cs
}