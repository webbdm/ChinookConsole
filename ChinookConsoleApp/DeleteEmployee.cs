using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{
    public class DeleteEmployee
    {
        public void Delete()
        {
            var employeeList = new ListEmployees();
            var firedEmployee = employeeList.List("Pick the Id of an employee to transition:");
            var y = Convert.ToInt32(firedEmployee);

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                //connection.Open();
                //var cmd = connection.CreateCommand();
                //cmd.CommandText = "Delete From Employee where EmployeeId = @EmployeeId";

                //var employeeIdParameter = cmd.Parameters.Add("@EmployeeId", SqlDbType.Int);
                //employeeIdParameter.Value = firedEmployee;

                try
                {
                    var affectedRows = connection.Execute("Delete From Employee where EmployeeId = @EmployeeId",
                        new { EmployeeId = y });

                    if (affectedRows == 1)
                    {
                        Console.WriteLine("Success");
                    }
                    else if (affectedRows > 1)
                    {
                        Console.WriteLine("AAAAHHHHHH");
                    }
                    else
                    {
                        Console.WriteLine("Failed to find a matching Id");
                    }

                    Console.WriteLine("Press enter to return to the menu");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}