<<<<<<< HEAD:Back/Models/UserInfoEntity.cs
using System.ComponentModel.DataAnnotations;

=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> e849b02351b97ec4425187c5143ec42a36389f3a:Back/Models/Entities/UserInfoEntity.cs
namespace Back.Models;
public class UserInfo
{
<<<<<<< HEAD:Back/Models/UserInfoEntity.cs
    [Key]
    public int UserId {get; set; }
=======
    public int Id { get; set; }
    [ForeignKey("Id")]
>>>>>>> e849b02351b97ec4425187c5143ec42a36389f3a:Back/Models/Entities/UserInfoEntity.cs
    public User? User{ get; set; }
    public required string Name { get; set; }
    public required string Surname{ get; set; }
    public required DateOnly Birthday{ get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
    public List<FavouriteSport> FavouriteSports{ get; set; } = [];
    public string? Description { get; set; }
}