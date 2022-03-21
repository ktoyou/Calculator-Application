namespace Calculator.Models
{
    internal class Minus : ICalculator
    {
        public float Calculate(float x, float y) => x - y;

        public string GetExpression() => "-";
    }
}
