namespace API.Dtos;

public class UserDto
{
        public int Id {get; set;}
        public string? Username {get; set;}
        public string? Email {get; set;}
        public ICollection<BasicVehicleDto>? Vehicles {get; set;}
}