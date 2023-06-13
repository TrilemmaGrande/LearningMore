using System;
using Xunit;

namespace Beispiel.TDD.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(7)]
        [InlineData(19)]
        [InlineData(37)]
        public void NumberNotDivisibleBy3And5_ReturnsTheNumber(int number)
        {
            // Arrange
            FizzBuzz fb = new FizzBuzz();
            // Act
            string result = fb.Play(number);
            // Assert
            Assert.Equal(number.ToString(), result);
        }
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(36)]
        [InlineData(303)]
        public void NumberOnlyDivisibleBy3_ReturnsFizz(int number)
        {
            // Arrange
            FizzBuzz fb = new FizzBuzz();
            // Act
            string result = fb.Play(number);
            // Assert
            Assert.Equal("Fizz", result);
        }
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(5105)]
        public void NumberOnlyDivisibleBy5_ReturnsBuzz(int number)
        {
            // Arrange
            FizzBuzz fb = new FizzBuzz();
            // Act
            string result = fb.Play(number);
            // Assert
            Assert.Equal("Buzz", result);
        }
        [Theory]
        [InlineData(15)]
        [InlineData(75)]
        [InlineData(150)]
        [InlineData(555)]
        public void NumberDivisibleBy3And5_ReturnsFizzBuzz(int number)
        {
            // Arrange
            FizzBuzz fb = new FizzBuzz();
            // Act
            string result = fb.Play(number);
            // Assert
            Assert.Equal("FizzBuzz", result);
        }
    }
}
