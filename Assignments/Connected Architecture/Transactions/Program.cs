using System;
using Transactions;

namespace Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*InsertIntoTables obj = new InsertIntoTables(); ; 

            
            obj.InsertRecordsusingtrans();

            Console.WriteLine("Execution completed.");
            Console.ReadLine(); */

            InsertFetch obj = new InsertFetch();
            obj.InsertAndFetchIdentity();

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();

           /* MultiResultReader obj = new MultiResultReader();
            obj.ReadMultipleResults();

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();*/
            /*MultipleOutPutParameters obj = new MultipleOutPutParameters();
            obj.GetEmployeeDetailsUsingSP();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();*/

        }
    }
}
