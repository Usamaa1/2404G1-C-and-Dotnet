namespace WebAPI.DTO
{
    public class SignupDTO
    {
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
    }
}
