﻿using InnovaApp.API.Services;
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

        public Order()
        {
        }

        public Order(OrderCreateRequestDto request)
        {
            OrderItems = request.OrderItems?.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Price = x.Price,
                Count = x.Count
            }).ToList();

            CheckSameProductItemLessThan2();

            CheckOrderItemCount();


            TotalPrice = OrderItems.Sum(x => x.Price * x.Count);

            OrderCode = Guid.NewGuid().ToString();
        }


        private void CheckOrderItemCount()
        {
            var totalItemCount = OrderItems!.Sum(x => x.Count);

            if (totalItemCount > 10)
            {
                throw new Exception("Sipariş adet sayısı 10'dan büyük olamaz");
            }
        }

        private void CheckSameProductItemLessThan2()
        {
            OrderItems?.ForEach(x =>
            {
                if (x.Count > 2)
                {
                    throw new Exception("Aynı üründen 2 taneden fazla olamaz");
                }
            });
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