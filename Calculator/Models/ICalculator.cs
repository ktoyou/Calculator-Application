namespace Calculator.Models
{
    internal interface ICalculator
    {
        float Calculate(float x, float y);

        string GetExpression();
    }
}
