using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeAndDepartment employee = new EmployeeAndDepartment();
            // employee.ShowDetails();
            // employee.EmployeeFilter();
            //employee.ShowTotalTables();
            //employee.CopyDepartment();
            //employee.MergeTables();
            employee.ReadXml();
            Console.ReadLine();
        }
    }
}
