using System;
using System.Data;
using System.Data.SqlClient;

class Class1
{
    static void Main()
    {
        string connectionString = "Data Source=ICS-LT-81RSBN3\\SQLEXPRESS01;Initial Catalog=Employeemanagement;Integrated Security=True";

        Console.Write("Enter Employee ID: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("sp_UpdateSalary", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Empno", employeeId);

            SqlParameter salaryOutput = new SqlParameter("@UpdatedSalary", SqlDbType.Decimal);
            salaryOutput.Direction = ParameterDirection.Output;

            command.Parameters.Add(salaryOutput);

            connection.Open();
            command.ExecuteNonQuery();

            Console.WriteLine("Updated Salary: " + command.Parameters["@UpdatedSalary"].Value);
        }
    }
}
