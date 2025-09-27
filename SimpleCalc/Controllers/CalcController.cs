using Microsoft.AspNetCore.Mvc;

namespace SimpleCalc.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalcController : ControllerBase
{
    /// <summary>
    /// Adds two numbers
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>The sum of a and b</returns>
    [HttpGet("add")]
    public ActionResult<double> Add(double a, double b)
    {
        return Ok(a + b);
    }

    /// <summary>
    /// Subtracts second number from first number
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number to subtract</param>
    /// <returns>The difference of a and b</returns>
    [HttpGet("subtract")]
    public ActionResult<double> Subtract(double a, double b)
    {
        return Ok(a - b);
    }

    /// <summary>
    /// Multiplies two numbers
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>The product of a and b</returns>
    [HttpGet("multiply")]
    public ActionResult<double> Multiply(double a, double b)
    {
        return Ok(a * b);
    }

    /// <summary>
    /// Divides first number by second number
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor</param>
    /// <returns>The quotient of a and b</returns>
    [HttpGet("divide")]
    public ActionResult<double> Divide(double a, double b)
    {
        if (b == 0)
        {
            return BadRequest("Division by zero is not allowed");
        }
        return Ok(a / b);
    }

    /// <summary>
    /// Calculates the power of a number
    /// </summary>
    /// <param name="baseNumber">Base number</param>
    /// <param name="exponent">Exponent</param>
    /// <returns>The result of baseNumber raised to the power of exponent</returns>
    [HttpGet("power")]
    public ActionResult<double> Power(double baseNumber, double exponent)
    {
        return Ok(Math.Pow(baseNumber, exponent));
    }

    /// <summary>
    /// Calculates the square root of a number
    /// </summary>
    /// <param name="number">Number to calculate square root for</param>
    /// <returns>The square root of the number</returns>
    [HttpGet("sqrt")]
    public ActionResult<double> SquareRoot(double number)
    {
        if (number < 0)
        {
            return BadRequest("Cannot calculate square root of negative number");
        }
        return Ok(Math.Sqrt(number));
    }
}
