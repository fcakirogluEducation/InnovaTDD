namespace InnovaApp.API.Services
{
    public class UserCreateRequestDto
    {
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;

        public string Phone { get; set; } = default!;
    }
}