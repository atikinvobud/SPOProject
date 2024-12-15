using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models;
 
public class Tournament
{
    public int Id { get; set; }
    public List<Request> Requests { get; set; } = [];
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int DateId{ get; set; }
    public Date? Date{ get; set; }
    public int LocationId{ get; set; }
    public Location? Location{ get; set; }
    public required bool IsPrivate { get; set; }
    public int SportId{ get; set; }
    public Sport? Sport{ get; set; }
    public int FormatId{ get; set; }
    public Format? Format{ get; set; }
    public string? contacts  { get; set; }
    public int? NotificationId { get; set; }
    public Notification? Notification{ get; set; }
    public required string Link { get; set; }
}