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
            List<string> wordList = new List<string> { "mum", "amsterdam", "bloom" };

            // LINQ query to find words starting with 'a' and ending with 'm'
            var filteredWords =
                from w in wordList
                where w.StartsWith("a") && w.EndsWith("m")
                select w;

            // Display output
            foreach (string w in filteredWords)
            {
                Console.WriteLine(w);
            }
        }
    }
}