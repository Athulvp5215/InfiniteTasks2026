using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment7
{
    class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public decimal Salary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create staff list
            List<Staff> staffList = new List<Staff>
            {
                new Staff { Id = 101, Name = "Arun", City = "Bangalore", Salary = 55000 },
                new Staff { Id = 102, Name = "Divya", City = "Chennai", Salary = 42000 },
                new Staff { Id = 103, Name = "Karthik", City = "Bangalore", Salary = 48000 },
                new Staff { Id = 104, Name = "Meena", City = "Hyderabad", Salary = 60000 },
                new Staff { Id = 105, Name = "Suresh", City = "Pune", Salary = 38000 }
            };

            // a. Display all staff
            Console.WriteLine("All Staff Members:");
            ShowStaff(staffList);

            // b. Staff with salary greater than 45000
            Console.WriteLine("\nStaff with Salary > 45000:");
            var salaryFilter =
                from s in staffList
                where s.Salary > 45000
                select s;
            ShowStaff(salaryFilter);

            // c. Staff from Bangalore
            Console.WriteLine("\nStaff from Bangalore:");
            var cityFilter =
                from s in staffList
                where s.City == "Bangalore"
                select s;
            ShowStaff(cityFilter);

            // d. Staff sorted by name
            Console.WriteLine("\nStaff Sorted by Name:");
            var nameSorted =
                from s in staffList
                orderby s.Name
                select s;
            ShowStaff(nameSorted);

            Console.ReadLine();
        }

        // Method to display staff details
        static void ShowStaff(IEnumerable<Staff> list)
        {
            foreach (var s in list)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, City: {s.City}, Salary: {s.Salary}");
            }
        }
    }
}