using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaApp.API.Services
{
    public class OrderCreateRequestDto
    {
        public List<OrderItemDto>? OrderItems { get; set; }
    }


    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}