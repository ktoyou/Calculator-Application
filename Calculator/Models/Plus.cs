namespace Calculator.Models
{
    internal class Plus : ICalculator
    {
        public float Calculate(float x, float y) => x + y;

        public string GetExpression() => "+";
    }
}
