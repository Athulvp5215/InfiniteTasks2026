using System;
using System.Data;
using System.Data.SqlClient;

namespace ConnectedADO
{
    class EmployeeApp
    {
        // ============================
        // DATABASE CONNECTION METHOD
        // ============================
        static SqlConnection GetConnection()
        {
            try
            {
                string connStr =
                    "Data Source=ICS-LT-81RSBN3\\SQLEXPRESS01;" +
                    "Database=SQLHandsON;" +
                    "Trusted_Connection=True;";

                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                return conn;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database connection failed!");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // ============================
        // DISPLAY ALL EMPLOYEES
        // ============================
        static void DisplayEmployees()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd =
                        new SqlCommand("SELECT * FROM employees", conn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine("\n---- Employee Details ----");
                    while (dr.Read())
                    {
                        Console.WriteLine(
                            $"{dr["employee_id"]} | " +
                            $"{dr["first_name"]} | " +
                            $"{dr["last_name"]} | " +
                            $"{dr["email"]} | " +
                            $"{Convert.ToDateTime(dr["hire_date"]).ToShortDateString()} | " +
                            $"{dr["salary"]}");
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error displaying employees: " + ex.Message);
            }
        }

        // ============================
        // INSERT EMPLOYEE
        // ============================
        static void InsertEmployee()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    Console.Write("Employee ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("First Name: ");
                    string fname = Console.ReadLine();

                    Console.Write("Last Name: ");
                    string lname = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Hire Date (yyyy-mm-dd): ");
                    DateTime hdate = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Salary: ");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO employees VALUES (@id,@fn,@ln,@em,@hd,@sal)",
                        conn);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@fn", fname);
                    cmd.Parameters.AddWithValue("@ln", lname);
                    cmd.Parameters.AddWithValue("@em", email);
                    cmd.Parameters.AddWithValue("@hd", hdate);
                    cmd.Parameters.AddWithValue("@sal", salary);

                    int rows = cmd.ExecuteNonQuery();

                    Console.WriteLine(rows > 0
                        ? "Employee Added Successfully ✅"
                        : "Insert Failed ❌");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting employee: " + ex.Message);
            }
        }

        // ============================
        // EMPLOYEE COUNT (ExecuteScalar)
        // ============================
        static void EmployeeCount()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd =
                        new SqlCommand("SELECT COUNT(employee_id) FROM employees", conn);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine("\nTotal Employees: " + count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting count: " + ex.Message);
            }
        }

        // ============================
        // HIGHEST SALARY EMPLOYEE
        // ============================
        static void HighestSalaryEmployee()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM employees " +
                        "WHERE salary = (SELECT MAX(salary) FROM employees)", conn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine("\n---- Highest Paid Employee ----");
                    while (dr.Read())
                    {
                        Console.WriteLine(
                            $"{dr["first_name"]} {dr["last_name"]} - Salary: {dr["salary"]}");
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching highest salary employee: " + ex.Message);
            }
        }

        // ============================
        // MAIN METHOD
        // ============================
        static void Main()
        {
            DisplayEmployees();
            InsertEmployee();
            EmployeeCount();
            HighestSalaryEmployee();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}