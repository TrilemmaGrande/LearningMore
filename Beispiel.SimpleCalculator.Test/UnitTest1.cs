using System;
using Xunit;

namespace Beispiel.SimpleCalculator.Test
{
    public class UnitTest1
    {
        [Fact]
        public void AddingTwoNumbersReturnsTheirSum()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            calc.Add(42);
            calc.Add(42);

            // Assert
            Assert.Equal(84, calc.Value);
        }
        [Theory]
        [InlineData(2,21,42)]
        [InlineData(1,1,1)]
        [InlineData(5,5,25)]
        [InlineData(0,1000,0)]
        public void MultiplyingTwoNumbersReturnsTheirProduct(decimal v1, decimal v2, decimal res)
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            calc.Mult(v1);
            calc.Mult(v2);

            // Assert
            Assert.Equal(res, calc.Value);
        }
    }
}
