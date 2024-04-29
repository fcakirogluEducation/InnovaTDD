using Microsoft.EntityFrameworkCore;

namespace InnovaApp.API.Repositories
{
    public class StockRepository(AppDbContext context) : IStockRepository
    {
        public async Task<bool> CheckStock(int productId, int quantity)
        {
            // check stock quantity
            var stock = await context.Stocks.FirstOrDefaultAsync(s => s.ProductId == productId);

            if (stock == null)
            {
                return false;
            }

            return stock.Quantity >= quantity;
        }
    }
}