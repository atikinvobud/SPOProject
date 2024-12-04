using System;
namespace Back.DTO.UserInfosDTO;
    public class UserInfoDTO
    {
        public int id { get; set; }
        public string? surname { get; set; }
        public string? name { get; set; }
        public string? gender { get; set; }
        public DateOnly dateOfBirth{ get; set; }
    }