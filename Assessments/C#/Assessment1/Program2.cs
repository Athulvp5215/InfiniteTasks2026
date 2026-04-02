using System;


struct BirthDate
{
    public int Day;
    public int Month;
    public int Year;
}

struct Staff
{
    public string Name;
    public BirthDate DOB;
}

class Program2
{
    static void Main()
    {
        Staff[] emp = new Staff[2];

        for (int i = 0; i < 2; i++)
        {
            try
            {
                Console.Write("\nName of the employee: ");
                emp[i].Name = Console.ReadLine();

                Console.Write("Input day of the birth: ");
                emp[i].DOB.Day = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input month of the birth: ");
                emp[i].DOB.Month = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input year for the birth: ");
                emp[i].DOB.Year = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again.");
                i--;
            }
        }

        Console.WriteLine("\nEmployee Details:");
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Name: " + emp[i].Name);
            Console.WriteLine($"DOB: {emp[i].DOB.Day}/{emp[i].DOB.Month}/{emp[i].DOB.Year}");
        }
    }
}
