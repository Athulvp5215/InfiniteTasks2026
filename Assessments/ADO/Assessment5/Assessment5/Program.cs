using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connStr = "Data Source=ICS-LT-81RSBN3\\SQLEXPRESS01;Initial Catalog=Employeemanagement;Integrated Security=True";

        //User Input
        Console.Write("Enter Employee Name: ");
        string empName = Console.ReadLine();

        Console.Write("Enter Employee Salary: ");
        decimal empSal = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter Employee Type (F/P): ");
        string empType = Console.ReadLine();

        using (SqlConnection con = new SqlConnection(connStr))
        {
            //Stored Procedure
            SqlCommand cmd = new SqlCommand("sp_AddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpName", empName);
            cmd.Parameters.AddWithValue("@Empsal", empSal);
            cmd.Parameters.AddWithValue("@Emptype", empType);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("\n Employee Inserted Successfully!\n");

            //Display
            SqlCommand display = new SqlCommand("SELECT * FROM Employee_Details", con);
            SqlDataReader reader = display.ExecuteReader();

            Console.WriteLine("Employee Records:");
            while (reader.Read())
            {
                Console.WriteLine(reader["Empno"] + " " +
                                  reader["EmpName"] + " " +
                                  reader["Empsal"] + " " +
                                  reader["Emptype"]);
            }

            con.Close();
        }
    }
}