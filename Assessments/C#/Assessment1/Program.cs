using System;
using System.Collections.Generic;

namespace EmployeeProject
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main()
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddEmployee(); break;
                        case 2: ViewEmployees(); break;
                        case 3: SearchEmployee(); break;
                        case 4: UpdateEmployee(); break;
                        case 5: DeleteEmployee(); break;
                        case 6: Console.WriteLine("Exiting..."); break;
                        default: Console.WriteLine("Invalid choice"); break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                    choice = 0;
                }

            } while (choice != 6);
        }

        static void AddEmployee()
        {
            Employee emp = new Employee();

            Console.Write("Enter ID: ");
            emp.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = Convert.ToDouble(Console.ReadLine());

            employees.Add(emp);
            Console.WriteLine("Employee added successfully.");
        }

        static void ViewEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (Employee e in employees)
            {
                Console.WriteLine($"ID:{e.Id} Name:{e.Name} Dept:{e.Department} Salary:{e.Salary}");
            }
        }

        static void SearchEmployee()
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee e = employees.Find(x => x.Id == id);
            if (e != null)
                Console.WriteLine($"ID:{e.Id} Name:{e.Name} Dept:{e.Department} Salary:{e.Salary}");
            else
                Console.WriteLine("Employee not found.");
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee e = employees.Find(x => x.Id == id);
            if (e != null)
            {
                Console.Write("New Name: ");
                e.Name = Console.ReadLine();

                Console.Write("New Department: ");
                e.Department = Console.ReadLine();

                Console.Write("New Salary: ");
                e.Salary = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Employee updated successfully.");
            }
            else
                Console.WriteLine("Employee not found.");
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee e = employees.Find(x => x.Id == id);
            if (e != null)
            {
                employees.Remove(e);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
                Console.WriteLine("Employee not found.");
        }
    }
}