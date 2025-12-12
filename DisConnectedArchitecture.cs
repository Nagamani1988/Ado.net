using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentOnAdo.net
{
    public  class DisConnectedArchitecture
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Disconnected Architecture: Load Students & Courses ===");
            string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=adonet;Integrated Security=True";
            DataSet ds = new DataSet("SchoolDS");


            string studentsSelect = "Select StudentId, FullName, Email From Students";
            string coursesSelect = "Select CourseId, Title, Credits From Courses";


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlDataAdapter studentsAdapter = new SqlDataAdapter(studentsSelect, conn))
            using (SqlDataAdapter coursesAdapter = new SqlDataAdapter(coursesSelect, conn))
            {

                using (SqlCommandBuilder studentsCb = new SqlCommandBuilder(studentsAdapter))
                using (SqlCommandBuilder coursesCb = new SqlCommandBuilder(coursesAdapter))
                {
                    try
                    {

                        studentsAdapter.Fill(ds, "Students");
                        coursesAdapter.Fill(ds, "Courses");


                        if (ds.Tables["Students"].Columns.Contains("StudentId"))
                            ds.Tables["Students"].PrimaryKey = new[] { ds.Tables["Students"].Columns["StudentId"] };

                        if (ds.Tables["Courses"].Columns.Contains("CourseId"))
                            ds.Tables["Courses"].PrimaryKey = new[] { ds.Tables["Courses"].Columns["CourseId"] };


                        PrintTable(ds.Tables["Students"], "Students");
                        PrintTable(ds.Tables["Courses"], "Courses");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error loading data: " + ex.Message);
                        Console.ResetColor();
                    }
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }


       public static void PrintTable(DataTable table, string title)
        {
            if (table == null)
            {
                Console.WriteLine($"\n[{title}] table not found.");
                return;
            }

            Console.WriteLine($"\n=== {title} ({table.Rows.Count} rows) ===");


            int[] widths = new int[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                int max = table.Columns[i].ColumnName.Length;
                foreach (DataRow row in table.Rows)
                {
                    var text = Convert.ToString(row[i]) ?? string.Empty;
                    if (text.Length > max) max = text.Length;
                }

                widths[i] = Math.Min(Math.Max(max, 8), 40);
            }


            for (int i = 0; i < table.Columns.Count; i++)
            {
                string name = table.Columns[i].ColumnName;
                Console.Write(Pad(name, widths[i]) + "  ");
            }
            Console.WriteLine();


            for (int i = 0; i < table.Columns.Count; i++)
            {
                Console.Write(new string('-', widths[i]) + "  ");
            }
            Console.WriteLine();


            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    string text = Convert.ToString(row[i]) ?? string.Empty;
                    Console.Write(Pad(text, widths[i]) + "  ");
                }
                Console.WriteLine();
            }
        }

        static string Pad(string s, int width)
        {
            if (s == null) s = string.Empty;
            if (s.Length > width) return s.Substring(0, width - 1) + "…";
            return s.PadRight(width);
        }
        //2nd question


        public static void Main()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=adonet;Integrated Security=True";
            string selectQuery = "Select CourseId, CourseName, Credits From Courses";

            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn))
            using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
            {
                adapter.Fill(ds, "Courses");
            }

            DataTable courses = ds.Tables["Courses"];


            Console.WriteLine("Courses:");
            foreach (DataRow row in courses.Rows)
                Console.WriteLine($"{row["CourseId"]} - {row["CourseName"]} - Credits: {row["Credits"]}");


            Console.Write("\nEnter CourseId: ");
            int courseId = int.Parse(Console.ReadLine());
            Console.Write("Enter new Credits: ");
            int newCredits = int.Parse(Console.ReadLine());


            DataRow courseRow = courses.Rows.Find(courseId);
            if (courseRow != null)
            {
                courseRow["Credits"] = newCredits;


                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.Update(ds, "Courses");
                }

                Console.WriteLine("Credits updated successfully!");
            }
            else
            {
                Console.WriteLine("CourseId not found.");
            }
        }
        //3rd question


        public static void Main()
        {
            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=adonet;Integrated Security=True";
            string query = "Select CourseId, CourseName, Credits, Semester From Courses";

            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            using (SqlCommandBuilder cb = new SqlCommandBuilder(da))
            {
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                da.Fill(ds, "Courses");
                DataTable courses = ds.Tables["Courses"];


                Console.Write("Course Name: ");
                string name = Console.ReadLine();
                Console.Write("Credits: ");
                int credits = int.Parse(Console.ReadLine());
                Console.Write("Semester: ");
                string semester = Console.ReadLine();


                DataRow newRow = courses.NewRow();
                newRow["CourseName"] = name;
                newRow["Credits"] = credits;
                newRow["Semester"] = semester;
                courses.Rows.Add(newRow);

                da.Update(ds, "Courses");
                Console.WriteLine("New course inserted successfully!");
            }
        }

        //4th question


        static void Main()
        {
            string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=adonet;IntegratedSecurity=True;";
            int studentId = 101;

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter adapter = new SqlDataAdapter("Select * From Students", conn))
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                DataTable dt = new DataTable();
                adapter.Fill(dt);


                DataRow[] rows = dt.Select($"StudentID = {studentId}");
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                    adapter.Update(dt);
                    Console.WriteLine("Student deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
        }

        //5th question

        static void Main(string[] args)
        {
            string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=adonet;Integrated Security=True;";
            string semester = "Fall2025";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("usp_GetCoursesBySemester", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@semester", semester);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);


                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row["CourseID"]} - {row["CourseName"]}");
                }
            }
        }
    }
}


    







