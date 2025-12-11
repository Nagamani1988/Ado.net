using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions;

namespace Transactions
{
    internal class InsertFetch
    {
        public void InsertAndFetchIdentity()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");

            try
            {
                con.Open();

                
                SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO Employee (EmpName, Salary, DateOfJoin, DeptID) " +
                    "VALUES (@EmpName, @Salary, @DateOfJoin, @DeptID); " +
                    "SELECT CAST(SCOPE_IDENTITY() AS int);",   
                    con);

                
                cmdInsert.Parameters.AddWithValue("@EmpName", "Parvathi");
                cmdInsert.Parameters.AddWithValue("@Salary", 60000);
                cmdInsert.Parameters.AddWithValue("@DateOfJoin", DateTime.Now);
                cmdInsert.Parameters.AddWithValue("@DeptID", 10);   

                int newEmpId = (int)cmdInsert.ExecuteScalar();
                Console.WriteLine("New EmpID = " + newEmpId);

                
                SqlCommand cmdFetch = new SqlCommand(
                    "SELECT EmpID, EmpName, Salary, DateOfJoin, DeptID " +
                    "FROM Employee WHERE EmpID = @EmpID", con);

                cmdFetch.Parameters.AddWithValue("@EmpID", newEmpId);

                SqlDataReader dr = cmdFetch.ExecuteReader();

                if (dr.Read())
                {
                    Console.WriteLine("\n--- Inserted Employee ---");
                    Console.WriteLine($"EmpID     : {dr["EmpID"]}");
                    Console.WriteLine($"EmpName   : {dr["EmpName"]}");
                    Console.WriteLine($"Salary    : {dr["Salary"]}");
                    Console.WriteLine($"DateOfJoin: {dr["DateOfJoin"]}");
                    Console.WriteLine($"DeptID    : {dr["DeptID"]}");
                }
                else
                {
                    Console.WriteLine("Record not found!");
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}

