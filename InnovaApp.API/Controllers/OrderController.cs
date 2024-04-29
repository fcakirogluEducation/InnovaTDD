using InnovaApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(
        IOrderRepository orderRepository,
        IStockRepository stockRepository,
        UnitOfWork unitOfWork) : ControllerBase
    {
        //create order endpoint
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            orderRepository.CreateOrder(order);

            unitOfWork.SaveChanges();

            return Ok();
        }
    }
}