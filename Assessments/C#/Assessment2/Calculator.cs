namespace AssignmentProject
{
    public delegate int CalculatorDelegate(int a, int b);

    public class Calculator
    {
        public static int Add(int a, int b) => a + b;
        public static int Subtract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;
    }
}