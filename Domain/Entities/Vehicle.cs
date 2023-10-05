namespace Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string? Model {get; set;}
        public int Year {get; set;}
        public string? Color {get; set;}
        public int IdUser {get; set;}
        public User? User {get; set;}
    }
}