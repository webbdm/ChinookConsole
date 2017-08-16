using System;
using System.Data.SqlClient;

namespace ChinookConsoleApp
{
    public class ListEmployees
    {
        public void List()
        {
            using (var connection = new SqlConnection("Server=(local);Database=chinook;Trusted_Connection=True;"))
            {
                var employeeListCommand = connection.CreateCommand();

                employeeListCommand.CommandText = "select employeeid as Id, firstname + ' ' + lastname as fullname from Employee";

                try
                {
                    connection.Open();
                    var reader = employeeListCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}.) {reader["FullName"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}