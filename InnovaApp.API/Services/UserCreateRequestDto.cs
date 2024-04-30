namespace InnovaApp.API.Services
{
    public class UserCreateRequestDto
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}