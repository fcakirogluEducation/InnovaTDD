namespace InnovaApp.API.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AnySameEmail(string email);
        Task<List<User>> GetAll();
        void CreateUser(User user);

        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}