using System;

namespace ConsoleApp
{
    
    class DisplayUtility
    {
        protected void PrintTitle(string heading)
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine(heading.ToUpper());
            Console.WriteLine("------------------------------------");
        }
    }

    // Bank Account related operations
    class BankAccount : DisplayUtility
    {
        public int AccountNumber { get; private set; }
        public string HolderName { get; private set; }
        public string TypeOfAccount { get; private set; }
        public double CurrentBalance { get; private set; }

        public BankAccount(int number, string name, string type, double openingBalance)
        {
            AccountNumber = number;
            HolderName = name;
            TypeOfAccount = type;
            CurrentBalance = openingBalance;
        }

        private void Deposit(double amount)
        {
            CurrentBalance += amount;
            Console.WriteLine($"Amount Credited : {amount}");
        }

        private void Withdraw(double amount)
        {
            if (amount > CurrentBalance)
            {
                Console.WriteLine("Transaction Failed : Insufficient Funds");
            }
            else
            {
                CurrentBalance -= amount;
                Console.WriteLine($"Amount Debited : {amount}");
            }
        }

        public void ProcessTransaction(char choice, double amount)
        {
            switch (char.ToUpper(choice))
            {
                case 'D':
                    Deposit(amount);
                    break;
                case 'W':
                    Withdraw(amount);
                    break;
                default:
                    Console.WriteLine("Invalid Transaction Option");
                    break;
            }
        }

        public void DisplayAccountInfo()
        {
            PrintTitle("Bank Account Details");
            Console.WriteLine($"Account No     : {AccountNumber}");
            Console.WriteLine($"Account Holder : {HolderName}");
            Console.WriteLine($"Account Type   : {TypeOfAccount}");
            Console.WriteLine($"Balance        : {CurrentBalance}");
        }
    }

    // Student academic details
    class StudentRecord : DisplayUtility
    {
        private readonly int[] subjectMarks = new int[5];

        public int RollNumber { get; }
        public string StudentName { get; }
        public string Course { get; }
        public int Semester { get; }
        public string Department { get; }

        public StudentRecord(int roll, string name, string course, int sem, string dept)
        {
            RollNumber = roll;
            StudentName = name;
            Course = course;
            Semester = sem;
            Department = dept;
        }

        public void InputMarks()
        {
            Console.WriteLine("\nEnter marks for 5 subjects:");
            for (int i = 0; i < subjectMarks.Length; i++)
            {
                Console.Write($"Subject {i + 1}: ");
                subjectMarks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void ShowStudentDetails()
        {
            PrintTitle("Student Information");
            Console.WriteLine($"Roll No   : {RollNumber}");
            Console.WriteLine($"Name      : {StudentName}");
            Console.WriteLine($"Course    : {Course}");
            Console.WriteLine($"Semester  : {Semester}");
            Console.WriteLine($"Branch    : {Department}");
            Console.WriteLine($"Marks     : {string.Join(", ", subjectMarks)}");
        }

        public void CalculateResult()
        {
            int total = 0;
            bool isFailed = false;

            foreach (int mark in subjectMarks)
            {
                if (mark < 35)
                    isFailed = true;

                total += mark;
            }

            double average = total / 5.0;
            Console.WriteLine($"\nAverage Score : {average}");

            if (isFailed)
                Console.WriteLine("Result : FAILED (Subject marks below 35)");
            else if (average < 50)
                Console.WriteLine("Result : FAILED (Average below 50)");
            else
                Console.WriteLine("Result : PASSED");
        }
    }

    // Sales information
    class SalesRecord : DisplayUtility
    {
        public int SalesId { get; }
        public int ItemId { get; }
        public double UnitPrice { get; }
        public int QuantitySold { get; }
        public string SaleDate { get; }

        private double FinalAmount;

        public SalesRecord(int saleId, int itemId, double price, int quantity, string date)
        {
            SalesId = saleId;
            ItemId = itemId;
            UnitPrice = price;
            QuantitySold = quantity;
            SaleDate = date;
        }

        public void CalculateTotal()
        {
            FinalAmount = UnitPrice * QuantitySold;
        }

        public void DisplaySaleInfo()
        {
            PrintTitle("Sales Summary");
            Console.WriteLine($"Sales ID     : {SalesId}");
            Console.WriteLine($"Product ID   : {ItemId}");
            Console.WriteLine($"Unit Price   : {UnitPrice}");
            Console.WriteLine($"Quantity     : {QuantitySold}");
            Console.WriteLine($"Sale Date    : {SaleDate}");
            Console.WriteLine($"Total Amount : {FinalAmount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Bank Demo
            BankAccount account = new BankAccount(201, "Athul", "Savings", 8000);
            account.ProcessTransaction('D', 2500);
            account.ProcessTransaction('W', 1800);
            account.DisplayAccountInfo();

            // Student Demo
            StudentRecord student = new StudentRecord(10, "Yuki", "BSc", 2, "IT");
            student.InputMarks();
            student.ShowStudentDetails();
            student.CalculateResult();

            // Sales Demo
            SalesRecord sales = new SalesRecord(3001, 700, 399.99, 3, "01-04-2026");
            sales.CalculateTotal();
            sales.DisplaySaleInfo();

            Console.WriteLine("\nApplication Execution Completed.");
        }
    }
}