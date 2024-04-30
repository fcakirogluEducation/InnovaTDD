using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using InnovaApp.API.Repositories;
using InnovaApp.API.Services;
using Moq;

namespace InnovaApp.API.Test
{
    public class UnitTestStyleTest
    {
        #region Output Style

        [Fact]
        public void CalculateDiscount_WhenDiscountRateIsLessThanZero_ThrowException()
        {
            //Arrange
            var order = OrderFactory.CreateOrderWithItems(1);

            //Act
            Action act = () => order.CalculateDiscount(-1);

            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("indirim oranı 0(%0) ile 1(%100) arasında olmalıdır (Parameter 'discountRate')");
            //indirim oranı 0(%0) ile 1(%100) arasında olmalıdır
        }

        [Fact]
        public void CalculateDiscount_WhenDiscountRateIsGreaterThanOne_ThrowException()
        {
            //Arrange
            var order = OrderFactory.CreateOrderWithItems(1);

            //Act
            Action act = () => order.CalculateDiscount(1.1m);

            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("indirim oranı 0(%0) ile 1(%100) arasında olmalıdır (Parameter 'discountRate')");
        }

        [InlineData(100, 0.5, 50)]
        [InlineData(100, 0.1, 10)]
        [Theory]
        public void CalculateDiscount_WhenDiscountRateIsBetweenZeroAndOne_ReturnDiscountedPrice(decimal price,
            decimal discountRate, decimal expectedCalculatedPrice)
        {
            //Arrange
            var order = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { Count = 1, Price = price }
                }
            };

            //Act
            var result = order.CalculateDiscount(discountRate);

            //Assert
            result.Should().Be(expectedCalculatedPrice);
        }

        #endregion


        #region State Style

        [Fact]
        public void AddOrderItem_WhenOrderItemsIsNull_AddNewOrderItem()
        {
            //Arrange
            var order = new Order();

            //Act
            order.AddOrderItem(10, 1, 1);

            //Assert
            order.OrderItems.Should().HaveCount(1);
            order.OrderItems.Should().Contain(x => x.ProductId == 1);
            order.OrderItems.Should().Contain(x => x.Price == 10);
        }

        #endregion


        [Fact]
        public async Task CreateUser_ValidUser_CheckCommunication()
        {
            //Arrange
            var userCreateRequestDto = new UserCreateRequestDto
            {
                Email = "ahmet@outlook.com",
                Password = "12345",
                Phone = "1234567890"
            };

            var smsServiceMock = new Mock<ISmsService>();
            var sut = new UserService(smsServiceMock.Object, new Mock<IUserRepository>().Object);

            await sut.CreateUser(userCreateRequestDto);

            //Assert
            //Check communication

            smsServiceMock.Verify(x => x.SendSsms(userCreateRequestDto.Phone, "Hoşgeldin mesajı"), Times.Once);
        }
    }
}