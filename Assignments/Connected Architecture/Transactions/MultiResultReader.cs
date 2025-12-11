using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions
{
    internal class MultiResultReader
    {
        
            public void ReadMultipleResults()
            {
                SqlConnection con = new SqlConnection(
                    "Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");

                try
                {
                    con.Open();

                    
                    SqlCommand cmd = new SqlCommand(
                        "Select EmpID, EmpName, Salary, DateOfJoin, DeptID FROM Employee;" +
                        "Select DeptID, DeptName From Department;", con);

                    SqlDataReader dr = cmd.ExecuteReader();

                    
                    Console.WriteLine("----- EMPLOYEES -----");
                    while (dr.Read())
                    {
                        Console.WriteLine(
                            $"{dr["EmpID"]}  {dr["EmpName"]}  {dr["Salary"]}  {dr["DateOfJoin"]}  {dr["DeptID"]}");
                    }

                    
                    dr.NextResult();

                    
                    Console.WriteLine("\n----- DEPARTMENTS -----");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["DeptID"]}  {dr["DeptName"]}");
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

