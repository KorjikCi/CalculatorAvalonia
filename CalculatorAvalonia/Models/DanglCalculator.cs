using System.Globalization;

namespace CalculatorAvalonia.Models;

public class DanglCalculator : ICalculator

{
    public string Calculate(string expression)
    {
        var calculation = Dangl.Calculator.Calculator.Calculate(expression);

        if (calculation.IsValid)
        {
            return calculation.Result.ToString(CultureInfo.InvariantCulture);
        }
        else
        {
            return calculation.ErrorMessage;
        }
    }
}