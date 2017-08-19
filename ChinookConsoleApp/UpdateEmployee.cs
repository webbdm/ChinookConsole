using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{
    public class UpdateEmployee
    {
        public void Update()
        {
            new ListEmployees().List("");
            Console.WriteLine("***************************************************");
            Console.WriteLine("Choose an employee to update, by employeeId number:");
            Console.WriteLine("***************************************************");
            var x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New Last Name:");
            var y = Console.ReadLine();
            Console.WriteLine(y);

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    var rowsAffected = connection.Execute("Update Employee " +
                                             "Set LastName = @updatedLastName " +
                                             "Where EmployeeId = @employeeId",

                                             new { employeeId = x, updatedLastName = y });

                    Console.WriteLine(rowsAffected != 1 ? "Add Failed" : "Success!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("You done messed up");
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }


                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}