using Microsoft.EntityFrameworkCore;

namespace InnovaApp.API.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public Task<bool> AnySameEmail(string email)
        {
            return context.Users.AnyAsync(x => x.Email == email);
        }
    }
}