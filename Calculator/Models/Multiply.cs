namespace Calculator.Models
{
    internal class Multiply : ICalculator
    {
        public float Calculate(float x, float y) => x * y;

        public string GetExpression() => "*";
    }
}
