using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------Welcome to Chinook---------------------");
            Console.WriteLine("------------Please select from the following options---------");
            Console.WriteLine("1. List Employees");
            Console.WriteLine("");
            Console.Write(">");
            var selection = Console.ReadLine();
            
            if (selection == "1") new ListEmployees().List();

            Console.ReadLine();
        }
    }
}
