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
    internal class MultipleOutPutParameters
    {
        public void GetEmployeeDetailsUsingSP()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");
            
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_GetEmployeeDet", con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                Console.Write("Enter Employee ID: ");
                int empid = int.Parse(Console.ReadLine());
                cmd.Parameters.AddWithValue("@EmpId", empid);

                
                SqlParameter doj = new SqlParameter("@DateofJoin", SqlDbType.Date);
                doj.Direction = ParameterDirection.Output;

                SqlParameter dept = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
                dept.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(doj);
                cmd.Parameters.Add(dept);

                
                cmd.ExecuteNonQuery();

                
                DateTime dateOfJoin = Convert.ToDateTime(cmd.Parameters["@DateofJoin"].Value);
                string department = cmd.Parameters["@Department"].Value.ToString();

                Console.WriteLine("\n----- Employee Summary -----");
                Console.WriteLine($"Employee ID : {empid}");
                Console.WriteLine($"Date Joined : {dateOfJoin:dd-MMM-yyyy}");
                Console.WriteLine($"Department  : {department}");
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






    
