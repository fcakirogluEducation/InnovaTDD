using InnovaApp.API.Repositories;

namespace InnovaApp.API.Services
{
    public class OrderService(IOrderRepository orderRepository, IStockRepository stockRepository, UnitOfWork unitOfWork)
        : IOrderService
    {
        public async Task CreateOrder(OrderCreateRequestDto request)
        {
            var order = new Order(request);


            orderRepository.CreateOrder(order);

            await unitOfWork.SaveChanges();
        }
    }
}