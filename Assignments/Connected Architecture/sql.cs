using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    internal class sql
    {
        public void GetTransactions(DateTime d1, DateTime d2)
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetEmployeeDate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FromDate", d1);
                cmd.Parameters.AddWithValue("@ToDate", d2);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["DeptId"]}   {dr["EmpName"]}   {dr["Salary"]}   {dr["DateofJoin"]}");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sql Error:" + ex.Message);

            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

        }
        public void GetCommonRecords(int id)
        { 
           SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("GetCommonRecords", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"ID: {dr["EmpID"]} , Name: {dr["EmpName"]}  ,  Salary: {dr["Salary"]}  ,  DOJ: {dr["DateOfJoin"]}");
                }
                dr.Close();
            }
             catch (Exception ex)
            { 

              Console.WriteLine("SQL Error: " + ex.Message);

            }
            finally
            { 

                con.Close();
            }

        }
    }
}
        
        


       
    

        
    
    
    
