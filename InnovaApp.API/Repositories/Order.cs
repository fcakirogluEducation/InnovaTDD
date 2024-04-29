using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaApp.API.Repositories
{
    public class Order
    {
        public int Id { get; set; }

        [StringLength(50)] public string OrderCode { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")] public decimal TotalPrice { get; set; }

        public List<OrderItem>? OrderItems { get; set; }


        public bool CheckOrderItemCount()
        {
            var totalItemCount = OrderItems!.Sum(x => x.Count);

            if (totalItemCount > 10)
            {
                return false;
                //throw new Exception("Sipariş adet sayısı 10'dan büyük olamaz");
            }

            return true;
        }
    }


    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}