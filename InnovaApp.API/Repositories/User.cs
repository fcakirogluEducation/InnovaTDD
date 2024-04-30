using InnovaApp.API.Services;

namespace InnovaApp.API.Repositories
{
    public partial class UserA
    {
    }

    public partial class UserA
    {
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

        public User()
        {
        }

        public static User CreateUser(UserCreateRequestDto request)
        {
            var user = new User() { Email = request.Email };

            return user;
        }
    }
}