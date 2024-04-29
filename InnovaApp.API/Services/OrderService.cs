using InnovaApp.API.Repositories;

namespace InnovaApp.API.Services
{
    public class OrderService(IOrderRepository orderRepository, IStockRepository stockRepository, UnitOfWork unitOfWork)
        : IOrderService
    {
        public async Task CreateOrder(Order order)
        {
            var result = order.CheckOrderItemCount();

            if (!result)
            {
                throw new Exception("Order item count is invalid");
            }

            orderRepository.CreateOrder(order);

            await unitOfWork.SaveChanges();
        }
    }
}