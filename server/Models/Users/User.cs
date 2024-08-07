namespace server.Models.Users
{
    public class User
    {   
        public int Id { get; set; }
        public string? Name { get; set; }
        // set unique for email

        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? phoneNumber { get; set; } = null;
    }
}