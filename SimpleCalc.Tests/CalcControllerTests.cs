using Microsoft.AspNetCore.Mvc;
using SimpleCalc.Controllers;
using Xunit;

namespace SimpleCalc.Tests;

public class CalcControllerTests
{
    private readonly CalcController _controller;

    public CalcControllerTests()
    {
        _controller = new CalcController();
    }

    [Theory]
    [InlineData(5.5, 3.2, 8.7)]
    [InlineData(0, 0, 0.0)]
    [InlineData(-5, -3, -8.0)]
    public void TestAdd(double a, double b, double expected)
    {
        // Act
        var result = _controller.Add(a, b);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(expected, okResult.Value);
    }

    [Theory]
    [InlineData(10, 4, 6.0)]
    [InlineData(3, 8, -5.0)]
    [InlineData(7, 7, 0.0)]
    public void TestSubtract(double a, double b, double expected)
    {
        // Act
        var result = _controller.Subtract(a, b);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(expected, okResult.Value);
    }

    [Theory]
    [InlineData(6, 7, 42.0)]
    [InlineData(5, 0, 0.0)]
    [InlineData(-4, -3, 12.0)]
    public void TestMultiply(double a, double b, double expected)
    {
        // Act
        var result = _controller.Multiply(a, b);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(expected, okResult.Value);
    }

    [Fact]
    public void Divide_ShouldReturnBadRequest_WhenDivisorIsZero()
    {
        // Arrange
        double a = 10;
        double b = 0;

        // Act
        var result = _controller.Divide(a, b);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Division by zero is not allowed", badRequestResult.Value);
    }

    [Theory]
    [InlineData(15, 3, 5.0)]
    [InlineData(7, 2, 3.5)]
    [InlineData(-12, 4, -3.0)]
    public void TestDivide(double a, double b, double expected)
    {
        // Act
        var result = _controller.Divide(a, b);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(expected, okResult.Value);
    }

    [Theory]
    [InlineData(2, 3, 8.0)]
    [InlineData(5, 0, 1.0)]
    [InlineData(2, -2, 0.25)]
    [InlineData(9, 0.5, 3.0)]
    public void TestPower(double baseNumber, double exponent, double expected)
    {
        // Act
        var result = _controller.Power(baseNumber, exponent);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(expected, okResult.Value);
    }

    [Fact]
    public void SquareRoot_ShouldReturnBadRequest_WhenNumberIsNegative()
    {
        // Arrange
        double number = -4;

        // Act
        var result = _controller.SquareRoot(number);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Cannot calculate square root of negative number", badRequestResult.Value);
    }

    [Theory]
    [InlineData(16, 4.0)]
    [InlineData(0, 0.0)]
    [InlineData(2, 1.4142135623730951)]
    public void TestSquareRoot(double number, double expected)
    {
        // Act
        var result = _controller.SquareRoot(number);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(expected, okResult.Value);
    }
}
