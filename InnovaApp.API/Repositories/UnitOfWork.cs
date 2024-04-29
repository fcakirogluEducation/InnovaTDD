namespace InnovaApp.API.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }
    }
}