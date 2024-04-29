using InnovaApp.API.Repositories;
using InnovaApp.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(
        IOrderService orderService) : ControllerBase
    {
        //create order endpoint
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await orderService.CreateOrder(order);

            return Ok();
        }
    }
}