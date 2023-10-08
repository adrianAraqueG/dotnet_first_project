namespace API.Dtos;

public class VehicleDto
{
    public int Id {get; set;}
    public string? Model {get; set;}
    public int Year {get; set;}
    public string? Color {get; set;}
    public int IdUser {get; set;}
    public BasicUserDto? User {get; set;}
}