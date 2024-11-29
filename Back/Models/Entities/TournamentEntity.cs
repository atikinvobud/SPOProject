using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models;
 
public class Tournament
{
    public int Id { get; set;}
<<<<<<< HEAD:Back/Models/TournamentEntity.cs
    public List<Request> Requests { get; set;} = [];
=======
    public Request? Request { get; set;}
>>>>>>> e849b02351b97ec4425187c5143ec42a36389f3a:Back/Models/Entities/TournamentEntity.cs
    public required string Name { get; set;}
    public string? Description { get; set;}
    public int DateId{ get; set;}
    public Date? Date{ get; set;}   
    public int LocationId{ get; set;}
    public Location? Location{ get; set;}
    public required bool IsPrivate { get; set;}
    public int SportId{ get; set;}
    public Sport? Sport{ get; set;}
    public int FormatId{ get; set;}
    public Format? Format{ get; set;}
    public int NotificationId { get; set;}
    public Notification? Notification{ get; set;}
    public required string Link { get; set;}
}