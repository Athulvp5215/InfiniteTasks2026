using System;
using System.IO;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowBooks();
            FileWriteRead();
            LineCount();

            Console.ReadLine();
        }

        static void ShowBooks()
        {
            string[] books =
            {
                "Harry Potter",
                "The Tempest",
                "Pride and Prejudice",
                "The Great Gatsby",
                "To Kill a Mockingbird"
            };

            string[] authors =
            {
                "J.K. Rowling",
                "William Shakespeare",
                "Jane Austen",
                "F. Scott Fitzgerald",
                "Harper Lee"
            };

            Console.WriteLine("--- Book Details ---");

            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"Book: {books[i]}, Author: {authors[i]}");
            }

            Console.WriteLine();
        }

        static void FileWriteRead()
        {
            string path = "books.txt";

            string[] bookList =
            {
                "Harry Potter",
                "The Tempest",
                "Pride and Prejudice",
                "The Great Gatsby",
                "To Kill a Mockingbird"
            };

            Console.WriteLine("--- Writing to File ---");
            File.WriteAllLines(path, bookList);
            Console.WriteLine("Books saved successfully.\n");

            Console.WriteLine("--- Reading from File ---");
            foreach (string book in File.ReadAllLines(path))
            {
                Console.WriteLine(book);
            }

            Console.WriteLine();
        }

        static void LineCount()
        {
            string path = "books.txt";

            int totalLines = File.ReadAllLines(path).Length;

            Console.WriteLine("--- Line Count ---");
            Console.WriteLine($"Total number of lines: {totalLines}");
        }
    }
}