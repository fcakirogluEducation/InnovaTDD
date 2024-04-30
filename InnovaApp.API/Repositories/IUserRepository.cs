namespace InnovaApp.API.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AnySameEmail(string email);
    }
}