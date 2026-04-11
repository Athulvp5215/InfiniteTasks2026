using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment7
{
    class Program
    {
        static void Main()
        {
            // Input data
            List<int> values = new List<int> { 7, 2, 30 };

            // LINQ query using query syntax
            var output =
                from v in values
                let square = v * v
                where square > 20
                select new
                {
                    Number = v,
                    Square = square
                };

            // Display result
            foreach (var data in output)
            {
                Console.WriteLine($"{data.Number} - {data.Square}");
            }
        }
    }
}