using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions
{
    internal class InsertIntoTables
    {
        public void InsertRecordsusingtrans()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");
            SqlTransaction tran = null;

            try
            {
                con.Open();

                
                tran = con.BeginTransaction();

                
                SqlCommand cmdDept = new SqlCommand(
                    "INSERT INTO Department (DeptID, DeptName) " +
                    "VALUES (@DeptID, @DeptName)",
                    con, tran);

                cmdDept.Parameters.AddWithValue("@DeptID", 80);
                cmdDept.Parameters.AddWithValue("@DeptName", "Management");

                cmdDept.ExecuteNonQuery();

                
                SqlCommand cmdEmp = new SqlCommand(
                    "INSERT INTO Employee (EmpName, Salary, DateOfJoin, DeptID) " +
                    "VALUES (@EmpName, @Salary, @DateOfJoin, @DeptID)",
                    con, tran);

                cmdEmp.Parameters.AddWithValue("@EmpName", "Sam");
                cmdEmp.Parameters.AddWithValue("@Salary", 80000);
                cmdEmp.Parameters.AddWithValue("@DateOfJoin", DateTime.Now);
                cmdEmp.Parameters.AddWithValue("@DeptID", 80);   

                cmdEmp.ExecuteNonQuery();

                
                tran.Commit();
                Console.WriteLine("Records inserted into Department and Employee (transaction committed).");
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();

                Console.WriteLine("SQL Error (transaction rolled back): " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

    }
}
