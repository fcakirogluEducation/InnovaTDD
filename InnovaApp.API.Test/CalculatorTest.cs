using FluentAssertions;
using InnovaApp.API.Services;

namespace InnovaApp.API.Test
{
    public class CalculatorTest
    {
        // write test calculator add method
        // write method name for
        [Fact]
        public void Add_PositiveTwoNumbers_ReturnsCorrectSum()
        {
            // Arrange
            var calculator = new Calculator();
            var a = 5;
            var b = 10;

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.Equal(15, result);
            result.Should().Be(15);
        }


        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(6, 3, 9)]
        public void Add2_PositiveTwoNumbers_ReturnsCorrectSum(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();


            // Act
            var actual = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, actual);
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(2, -3)]
        [InlineData(-2, -3)]
        [InlineData(-2, 3)]
        public void Add_NegativeNumber_ReturnException(int a, int b)
        {
            var sut = new Calculator(); // System Under Test

            Action result = () => sut.Add(a, b);

            //var exception = Assert.Throws<Exception>(result);

            //Assert.Equal("Invalid input", exception.Message);

            result.Should().Throw<Exception>().WithMessage("Invalid input");
        }
    }
}