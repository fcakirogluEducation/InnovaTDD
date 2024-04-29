using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using InnovaApp.API.Repositories;
using InnovaApp.API.Services;

namespace InnovaApp.API.Test
{
    public class OrderDtoFactory
    {
        public static OrderCreateRequestDto CreateOrderWithItems(int count)
        {
            return new OrderCreateRequestDto
            {
                OrderItems = Enumerable.Range(1, count).Select(x => new OrderItemDto
                        { ProductId = count, Count = 1, Price = count * 10 })
                    .ToList()
            };
        }


        public static OrderCreateRequestDto CreateOrderWithThreeCountSameProductItem()
        {
            return new OrderCreateRequestDto
            {
                OrderItems = new List<OrderItemDto>
                {
                    new OrderItemDto
                    {
                        ProductId = 1,
                        Count = 3,
                        Price = 10
                    }
                }
            };
        }
    }


    public class OrderFactory
    {
        //static factory method
        public static Order CreateOrderWithItems(int count)
        {
            return new Order
            {
                OrderItems = Enumerable.Range(1, count).Select(x => new OrderItem { Count = 1, Price = count * 10 })
                    .ToList()
            };
        }
    }


    public class OrderTest
    {
        public OrderTest()
        {
        }


        [Fact]
        public void create_order_success_when_valid_order_item()
        {
            // create order instance with order items
            var orderDto = OrderDtoFactory.CreateOrderWithItems(9);

            var sut = new Order(orderDto);

            sut.OrderItems.Count.Should().Be(9);
            sut.OrderItems.Sum(x => x.Price).Should().Be(810);
        }


        [Fact]
        public void create_order_fail_when_be_greater_than_same_order_item_two_count()
        {
            // create order instance with order items
            var orderDto = OrderDtoFactory.CreateOrderWithThreeCountSameProductItem();


            var action = () => new Order(orderDto);


            action.Should().Throw<Exception>().WithMessage("Aynı üründen 2 taneden fazla olamaz");
        }

        //[Fact]
        //public void CheckOrderItemCount_LessThan10Count_ReturnSuccess()
        //{
        //    // create order instance with order items
        //    var sut = OrderFactory.CreateOrderWithItems(9);

        //    var result = sut.CheckOrderItemCount();

        //    result.Should().BeTrue();
        //}


        //[Fact]
        //public void CheckOrderItemCount_GreaterThan10Count_ReturnFalse()
        //{
        //    // create order instance with order items
        //    var sut = OrderFactory.CreateOrderWithItems(11);

        //    var result = sut.CheckOrderItemCount();

        //    result.Should().BeFalse();
        //}
    }
}