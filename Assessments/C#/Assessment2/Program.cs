using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentProject
{
    class Program
    {
        static void PerformOperation(int a, int b, CalculatorDelegate operation, string name)
        {
            Console.WriteLine($"{name}: {operation(a, b)}");
        }

        static void Main(string[] args)
        {
            // ===== QUESTION 1 =====
            Console.WriteLine("QUESTION 1\n");

            Student ug = new Undergraduate
            {
                Name = "Arjun",
                StudentId = 101,
                Grade = 75
            };

            Student pg = new Graduate
            {
                Name = "Meera",
                StudentId = 102,
                Grade = 78
            };

            Console.WriteLine($"Student Name   : {ug.Name}");
            Console.WriteLine("Student Type   : Undergraduate");
            Console.WriteLine($"Passed         : {ug.IsPassed(ug.Grade)}");

            Console.WriteLine();

            Console.WriteLine($"Student Name   : {pg.Name}");
            Console.WriteLine("Student Type   : Graduate");
            Console.WriteLine($"Passed         : {pg.IsPassed(pg.Grade)}");

            // ===== QUESTION 2 =====
            Console.WriteLine("\nQUESTION 2");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Product> products = new List<Product>
            {
                new Product{ProductId=1, ProductName="Pen", Price=10},
                new Product{ProductId=2, ProductName="Notebook", Price=50},
                new Product{ProductId=3, ProductName="Bag", Price=500},
                new Product{ProductId=4, ProductName="Bottle", Price=120},
                new Product{ProductId=5, ProductName="Pencil", Price=5},
                new Product{ProductId=6, ProductName="Shoes", Price=1500},
                new Product{ProductId=7, ProductName="Watch", Price=2000},
                new Product{ProductId=8, ProductName="Phone", Price=15000},
                new Product{ProductId=9, ProductName="Mouse", Price=700},
                new Product{ProductId=10, ProductName="Keyboard", Price=900}
            };

            var sortedProducts = products.OrderBy(p => p.Price);

            foreach (var p in sortedProducts)
            {
                Console.WriteLine($"{p.ProductId} - {p.ProductName} - ₹{p.Price}");
            }

            // ===== QUESTION 3 =====
            Console.WriteLine("\nQUESTION 3");
            try
            {
                Console.Write("Enter a number: ");
                int num = Convert.ToInt32(Console.ReadLine());
                NumberValidator.CheckNumber(num);
                Console.WriteLine("Valid number entered");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            // ===== QUESTION 4 =====
            Console.WriteLine("\nQUESTION 4");

            Console.Write("Enter First Number: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            int y = Convert.ToInt32(Console.ReadLine());

            PerformOperation(x, y, Calculator.Add, "Addition");
            PerformOperation(x, y, Calculator.Subtract, "Subtraction");
            PerformOperation(x, y, Calculator.Multiply, "Multiplication");
        }
    }
}