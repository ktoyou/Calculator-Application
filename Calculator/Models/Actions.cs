namespace Calculator.Models
{
    internal class Actions
    {
        public static Actions ActionsInstance = new Actions();

        public ICalculator Divide { get; set; } = new Divide();

        public ICalculator Plus { get; set; } = new Plus();

        public ICalculator Minus { get; set; } = new Minus();

        public ICalculator Multiply { get; set; } = new Multiply();
    }
}
