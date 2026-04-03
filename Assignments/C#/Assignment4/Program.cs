using System;
using System.Collections.Generic;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RemoveAtPosition();
            SwapFirstAndLast();
            StackSort();
            Console.ReadLine();
        }

        public static void RemoveAtPosition()
        {
            Console.WriteLine("Enter a string:");
            string s = Console.ReadLine();

            Console.WriteLine("Enter position to remove:");
            int pos = int.Parse(Console.ReadLine());

            for (int i = 0; i < s.Length; i++)
            {
                if (i != pos)
                    Console.Write(s[i]);
            }
            Console.WriteLine();
        }

        public static void SwapFirstAndLast()
        {
            Console.WriteLine("=-=-=-=- Swap First and Last =-=-=-=-");
            Console.WriteLine("Enter a string:");
            string s = Console.ReadLine();

            if (s.Length <= 1)
            {
                Console.WriteLine(s);
            }
            else
            {
                Console.Write(s[s.Length - 1]);

                for (int i = 1; i < s.Length - 1; i++)
                {
                    Console.Write(s[i]);
                }

                Console.WriteLine(s[0]);
            }
        }

        public static void StackSort()
        {
            Console.WriteLine("=-=-=-=- Stack Sort Descending =-=-=-=-");
            Console.WriteLine("Enter number of elements:");
            int n = int.Parse(Console.ReadLine());

            Stack<int> st = new Stack<int>();

            Console.WriteLine("Enter stack elements:");
            for (int i = 0; i < n; i++)
            {
                st.Push(int.Parse(Console.ReadLine()));
            }

            int[] arr = st.ToArray();
            Array.Sort(arr);
            Array.Reverse(arr);

            Console.WriteLine("Sorted Stack:");
            foreach (int x in arr)
            {
                Console.WriteLine(x);
            }
        }
    }
}