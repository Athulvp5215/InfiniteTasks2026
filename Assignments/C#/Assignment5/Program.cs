using System;

class Program
{
    static void Main(string[] args)
    {
        BankTransaction();
        ScholarshipCalculation();
        BookShelfProgram();

        Console.WriteLine("\nAll Programs Executed Successfully.");
    }

    // Custom Exception for Banking
    class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    // Custom Exception for Scholarship
    class InvalidMarksException : ApplicationException
    {
        public InvalidMarksException(string message) : base(message)
        {
        }
    }

    // ---------------- BANK PROGRAM ----------------
    static void BankTransaction()
    {
        try
        {
            Console.WriteLine("\n--- BANKING SYSTEM ---");

            Console.Write("Enter Initial Balance: ");
            double balance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Deposit Amount: ");
            double deposit = Convert.ToDouble(Console.ReadLine());
            balance += deposit;

            Console.Write("Enter Withdrawal Amount: ");
            double withdraw = Convert.ToDouble(Console.ReadLine());

            if (withdraw > balance)
            {
                throw new InsufficientBalanceException("Insufficient balance for withdrawal.");
            }

            balance -= withdraw;

            Console.WriteLine("Final Balance: " + balance);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Custom Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("System Exception: " + ex.Message);
        }
    }

    // ---------------- SCHOLARSHIP PROGRAM ----------------
    static void ScholarshipCalculation()
    {
        try
        {
            Console.WriteLine("\n--- SCHOLARSHIP PROGRAM ---");

            Console.Write("Enter Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Fees: ");
            double fees = Convert.ToDouble(Console.ReadLine());

            double scholarshipAmount;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = fees * 0.20;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = fees * 0.30;
            }
            else if (marks > 90)
            {
                scholarshipAmount = fees * 0.50;
            }
            else
            {
                throw new InvalidMarksException("Marks below 70. No Scholarship.");
            }

            Console.WriteLine("Scholarship Amount: " + scholarshipAmount);
        }
        catch (InvalidMarksException ex)
        {
            Console.WriteLine("User Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("System Exception: " + ex.Message);
        }
    }

    // ---------------- BOOKSHELF PROGRAM ----------------
    static void BookShelfProgram()
    {
        Console.WriteLine("\n--- BOOKSHELF PROGRAM ---");

        string[] bookNames = new string[5];
        string[] authorNames = new string[5];

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter Book {i + 1} Name: ");
            bookNames[i] = Console.ReadLine();

            Console.Write($"Enter Author {i + 1} Name: ");
            authorNames[i] = Console.ReadLine();
        }

        Console.WriteLine("\nBook Details:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Book Name: " + bookNames[i] +
                              ", Author: " + authorNames[i]);
        }
    }
}