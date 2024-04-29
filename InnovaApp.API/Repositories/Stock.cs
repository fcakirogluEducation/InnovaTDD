using System.ComponentModel.DataAnnotations;

namespace InnovaApp.API.Repositories
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}