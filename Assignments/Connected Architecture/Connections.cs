using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet
{
    internal class Connections
    {
        public void ShowEmployee()
        {
            // display all records from employee table

            SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server= (localdb)\\MSSQLLocalDB");
            con.Open(); // creates a new connection

            // writes a command

            SqlCommand cmd = new SqlCommand("select * from employee", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) // run the loop only if record is found 
            {
                // it reads row by row

                Console.WriteLine($"{dr[0]}   {dr[1]}   {dr[2]}    {dr[3]}    {dr[4]}");

            }



            con.Close();

        }

        public void AddEmployee()
        {
            // Add records to employee table
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");
            con.Open(); // creates a new connection

            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Salary: ");
            int salary=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date: ");
            string date=Console.ReadLine();

            SqlCommand cmd = new SqlCommand("insert into employee values('Raj',30000,'1-1-2025',10)", con);

            int rowaffected = cmd.ExecuteNonQuery();

            Console.WriteLine("Total Records Inserted is " + rowaffected);


            con.Close();



        }

        public void DeleteEmployee()
        {
            //delete employee by id

            SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee  where EmpID=25", con);

            int rowaffected = cmd.ExecuteNonQuery();

            Console.WriteLine("Deleted " + rowaffected);
            con.Close();
        }

        public void UpdateEmployee()
        {
            // update to employee table
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Employee set Salary=58000 where EmpID=18", con);

            int rowaffected = cmd.ExecuteNonQuery();

            Console.WriteLine("Updated" + rowaffected);
            con.Close();

        }
    }
}












