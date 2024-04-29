namespace InnovaApp.API.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}