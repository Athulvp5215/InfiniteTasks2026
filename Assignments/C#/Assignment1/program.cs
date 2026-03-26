using System;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1.CheckEquality();
            Task2.CheckNumberType();
            Task3.BasicCalculator();
            Task4.GenerateTable();
            Task5.SumOrTriple();
        }
    }

    
    internal class Task1
    {
        public static void CheckEquality()
        {
            Console.Write("Enter first value: ");
            int firstValue = int.Parse(Console.ReadLine());

            Console.Write("Enter second value: ");
            int secondValue = int.Parse(Console.ReadLine());

            if (firstValue == secondValue)
            {
                Console.WriteLine($"Both numbers ({firstValue}, {secondValue}) are equal.");
            }
            else
            {
                Console.WriteLine($"The numbers {firstValue} and {secondValue} are different.");
            }
        }
    }

    
    internal class Task2
    {
        public static void CheckNumberType()
        {
            Console.Write("Enter a number to evaluate: ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n > 0)
                Console.WriteLine($"{n} is positive.");
            else if (n < 0)
                Console.WriteLine($"{n} is negative.");
            else
                Console.WriteLine("You entered zero.");
        }
    }

    
    internal class Task3
    {
        public static void BasicCalculator()
        {
            Console.Write("Enter the first number: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"Addition: {a} + {b} = {a + b}");
            Console.WriteLine($"Subtraction: {a} - {b} = {a - b}");
            Console.WriteLine($"Multiplication: {a} * {b} = {a * b}");

            if (b != 0)
                Console.WriteLine($"Division: {a} / {b} = {a / b}");
            else
                Console.WriteLine("Division not possible (second number is zero).");
        }
    }

    
    internal class Task4
    {
        public static void GenerateTable()
        {
            Console.Write("Enter a value to display its multiplication table: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"Multiplication table for {number}:");

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} × {i} = {number * i}");
            }
        }
    }

    
    internal class Task5
    {
        public static void SumOrTriple()
        {
            Console.Write("Enter first integer: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Enter second integer: ");
            int y = int.Parse(Console.ReadLine());

            int total = x + y;

            if (x == y)
            {
                Console.WriteLine($"Same numbers detected! Triple of sum: {total * 3}");
            }
            else
            {
                Console.WriteLine($"Sum of {x} and {y} = {total}");
            }
        }
    }
}