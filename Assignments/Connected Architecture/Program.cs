using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sql con = new sql();

            ////Console.WriteLine("Enter From Date (yyyy-mm-dd):");
            ////DateTime d1 = DateTime.Parse(Console.ReadLine());

            /// Console.WriteLine("Enter To Date (yyyy-mm-dd):");
            ////DateTime d2 = DateTime.Parse(Console.ReadLine());
            ///con.GetTransactions(d1, d2);
            Console.WriteLine("Enter the Id: ");
            int id = int.Parse(Console.ReadLine());
            con.GetCommonRecords(id);

            Console.ReadKey();
        }
    }
    
}
