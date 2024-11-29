namespace Back.Models;

public class Date
{
    public int Id { get; set; }
    public required DateOnly Start { get; set; }
    public required DateOnly End { get; set; }
<<<<<<< HEAD:Back/Models/DateEntity.cs
=======
    public Tournament? Tournament { get; set; }
>>>>>>> e849b02351b97ec4425187c5143ec42a36389f3a:Back/Models/Entities/DateEntity.cs
}