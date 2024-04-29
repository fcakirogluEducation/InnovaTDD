namespace InnovaApp.API.Repositories
{
    public interface IStockRepository
    {
        //check stock
        Task<bool> CheckStock(int productId, int quantity);
    }
}