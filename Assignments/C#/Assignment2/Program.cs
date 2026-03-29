using System;
using System.Linq;

namespace IndependentSampleProgram
{
    class Program
    {
        static void Main()
        {
            PrintGrid();
            ShowDayFromInput();
            AnalyzeUserArray();
            ProcessMarks();
            DuplicateArray();
            StringUtilities();
        }

        // 1. Jagged array display
        static void PrintGrid()
        {
            int rows = 4;
            int[][] matrix = Enumerable.Range(0, rows)
                                       .Select(x => Enumerable.Repeat(25, rows).ToArray())
                                       .ToArray();

            for (int i = 0; i < matrix.Length; i++)
            {
                foreach (int value in matrix[i])
                {
                    Console.Write((i % 2 == 1) ? value.ToString() : value + " ");
                }
                Console.WriteLine();
            }

            Divider();
        }

        // 2. Day printer
        static void ShowDayFromInput()
        {
            Console.Write("Enter a number (1-7): ");
            int input = int.Parse(Console.ReadLine());

            string[] week = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            Console.WriteLine($"Day: {week[(input - 1) % week.Length]}");

            Divider();
        }

        // 3. Average, Min, Max (dynamic array)
        static void AnalyzeUserArray()
        {
            Console.Write("How many numbers? ");
            int count = int.Parse(Console.ReadLine());

            int[] numbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Average: {numbers.Average()}");
            Console.WriteLine($"Minimum: {numbers.Min()}");
            Console.WriteLine($"Maximum: {numbers.Max()}");

            Divider();
        }

        // 4. Marks processing
        static void ProcessMarks()
        {
            int[] marks = new int[10];

            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"Enter mark {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nAscending Order:");
            foreach (var m in marks.OrderBy(x => x))
                Console.Write(m + " ");

            Console.WriteLine("\nDescending Order:");
            foreach (var m in marks.OrderByDescending(x => x))
                Console.Write(m + " ");

            Console.WriteLine($"\nTotal: {marks.Sum()}");
            Console.WriteLine($"Average: {marks.Average()}");
            Console.WriteLine($"Lowest: {marks.Min()}");
            Console.WriteLine($"Highest: {marks.Max()}");

            Divider();
        }

        // 5. Array duplication
        static void DuplicateArray()
        {
            int[] source = new int[3];

            for (int i = 0; i < source.Length; i++)
            {
                Console.Write($"Enter value {i + 1}: ");
                source[i] = int.Parse(Console.ReadLine());
            }

            int[] copy = source.ToArray();

            Console.WriteLine("Copied values:");
            foreach (int item in copy)
                Console.Write(item + " ");

            Divider();
        }

        // 6. String tools
        static void StringUtilities()
        {
            Console.Write("Enter a word: ");
            string text = Console.ReadLine();

            Console.WriteLine($"Length: {text.Length}");
            Console.WriteLine($"Reverse: {new string(text.Reverse().ToArray())}");

            Console.Write("Enter another word to compare: ");
            string compare = Console.ReadLine();

            Console.WriteLine(text.Equals(compare)
                ? "Strings match"
                : "Strings do not match");
        }

        static void Divider()
        {
            Console.WriteLine("\n--------------------------------\n");
        }
    }
}