using Microsoft.EntityFrameworkCore;

namespace InnovaApp.API.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public Task<bool> AnySameEmail(string email)
        {
            return context.Users.AnyAsync(x => x.Email == email);
        }


        //getall method
        public Task<List<User>> GetAll()
        {
            return context.Users.ToListAsync();
        }


        public void CreateUser(User user)
        {
            context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
        }
    }
}