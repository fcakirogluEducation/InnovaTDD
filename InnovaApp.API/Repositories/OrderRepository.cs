namespace InnovaApp.API.Repositories
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public void CreateOrder(Order order)
        {
            context.Orders.Add(order);
        }
    }
}