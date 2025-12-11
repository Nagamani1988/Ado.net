using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class EmployeeAndDepartment
    {
        SqlConnection con = new SqlConnection("Integrated security=true;database=dbnet;server=(localdb)\\MSSQLLocalDB");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da;

        public void ShowDetails()
        {

            SqlDataAdapter daEmp = new SqlDataAdapter("select * from Employee", con);
            daEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daEmp.Fill(ds, "Employee");
            SqlDataAdapter daDept = new SqlDataAdapter("select * from Department", con);
            daDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daDept.Fill(ds, "Department");
            Console.WriteLine("\nEmployee Table\n");
            DataTable EmpTable = ds.Tables["Employee"];
            for (int i = 0; i < EmpTable.Rows.Count; i++)
            {
                for (int j = 0; j < EmpTable.Columns.Count; j++)
                {
                    Console.Write(EmpTable.Rows[i][j] + "\t");
                }
                Console.WriteLine();

            }

            Console.WriteLine("\nDepartment\n");
            DataTable DeptTable = ds.Tables["Department"];
            for (int i = 0; i < DeptTable.Rows.Count; i++)
            {
                for (int j = 0; j < DeptTable.Columns.Count; j++)
                {
                    Console.Write(DeptTable.Rows[i][j] + "\t");
                }
                Console.WriteLine();

            }

        }


        /// 2nd question////
        public void EmployeeFilter()
        {
            if (!ds.Tables.Contains("Employee"))
            {
                SqlDataAdapter daEmp = new SqlDataAdapter("SELECT * FROM Employee", con);
                daEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                daEmp.Fill(ds, "Employee");
            }
            DataTable EmpTable = ds.Tables["Employee"];
            DataView dv = new DataView(EmpTable);
            dv.RowFilter = "Salary > 47000 and DeptID = 10 and EmpName like 'A%'";
            dv.Sort = "EmpName ASC";
            Console.WriteLine("\n Filtered Employee Table \n");
            for (int i = 0; i < dv.Count; i++)
            {
                for (int j = 0; j < dv.Table.Columns.Count; j++)
                {
                    Console.Write(dv[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n==================================");
        }


        /// 3rd question/////
        public void ShowTotalTables()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(
                   "SELECT COUNT(*) AS TotalTables FROM sys.tables", con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Console.WriteLine(
                        "The Total Number of Tables in Database : " +
                         dt.Rows[0]["TotalTables"]);
            }
            else
            {

                Console.WriteLine("No data returned from database.");
            }

        }
        ////4th question/////
        public void CopyDepartment()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Department", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            Console.WriteLine("\n Department Details \n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        /////5th question/////
        public void MergeTables()
        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            SqlDataAdapter daEmp = new SqlDataAdapter("select * from Employee", con);
            daEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daEmp.Fill(ds1, "Employee");

            SqlDataAdapter daDept = new SqlDataAdapter("select * from Department", con);
            daDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daDept.Fill(ds2, "Department");

            ds1.Merge(ds2);

            DataTable EmpTable = ds1.Tables[0];
            Console.WriteLine("\nEmployee Table\n");
            for (int i = 0; i < EmpTable.Rows.Count; i++)
            {
                for (int j = 0; j < EmpTable.Columns.Count; j++)
                {
                    Console.Write(EmpTable.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }


            DataTable DeptTable = ds1.Tables[1];
            Console.WriteLine("\nDepartment Table\n");
            for (int i = 0; i < DeptTable.Rows.Count; i++)
            {
                for (int j = 0; j < DeptTable.Columns.Count; j++)
                {
                    Console.Write(DeptTable.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }

        }
        ////6th question//




        public void ReadXml()
        {
            DataSet ds = new DataSet();

            
            ds.ReadXml("C:\\infinite_oct_2025\\Notepad\\CUSTOMER.xml");
       
            Console.WriteLine("Customer Details:\n");

            foreach (DataRow row in ds.Tables["CUST"].Rows)
            {
                Console.WriteLine("Customer ID      : " + row["CUSTID"]);
                Console.WriteLine("Customer Name    : " + row["CUSTNAME"]);
                Console.WriteLine("Customer Address : " + row["CUSTADDRESS"]);
                Console.WriteLine("Phone Number     : " + row["PHONE"]);
                Console.WriteLine("--------------------------------------");
            }

            Console.ReadLine();
        }
    }
}







