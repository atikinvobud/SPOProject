using System;
namespace Back.DTO.UserInfosDTO;
public record UserInfoDTO
{
    public int id { get; set; }
    public string? surname { get; set; }
    public string? name { get; set; }
    public string? gender { get; set; }
    public DateOnly dateOfBirth{ get; set; }
}