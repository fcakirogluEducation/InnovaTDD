using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssert;
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
            result.ShouldBeEqualTo(15);
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
            actual.ShouldBeEqualTo(expected);
        }
    }
}