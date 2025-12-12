using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentOnAdo.net
{
    internal class ConnectedArchitecture
    {
        public void DisplayAllCourses()
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=adonet;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT CourseId, CourseName, Credits, Semester FROM Courses";
             SqlCommand cmd = new SqlCommand(query, con);
             con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("CourseId   CourseName                Credits   Semester");
            Console.WriteLine("-----------------------------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(
                    dr["CourseId"] + "         " +
                    dr["CourseName"] + "        " +
                    dr["Credits"] + "          " +
                    dr["Semester"]
                );
            }

            con.Close();
        }
        //2nd question
        public void AddStudent(string fullName, string email, string department, int year)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=adonet;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            string query = @"Insert Into Students (FullName, Email, Department, YearOfStudy)
                     Values (@FullName, @Email, @Department, @YearOfStudy)";

            SqlCommand cmd = new SqlCommand(query, con);

            
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Department", department);
            cmd.Parameters.AddWithValue("@YearOfStudy", year);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine(rows + " student inserted successfully.");
        }
        //3rd question
        public void SearchStudentsByDepartment(string department)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=adonet;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);

            string query = @"Select StudentId, FullName, Email, Department, YearOfStudy
                     From Students
                     Where Department = @Department";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Department", department);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("\nStudents in Department: " + department);
            Console.WriteLine("--------------------------------------------");

            bool found = false;

            while (dr.Read())
            {
                found = true;
                Console.WriteLine(
                    dr["StudentId"] + "   " +
                    dr["FullName"] + "   " +
                    dr["Email"] + "   " +
                    dr["YearOfStudy"]
                );
            }

            if (!found)
            {
                Console.WriteLine("No students found.");
            }

            con.Close();
        }
        //4th question
        public void DisplayEnrolledCourses(int studentId)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=adonet;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);

            string query = @"
        Select c.CourseName, c.Credits, e.EnrollDate, e.Grade
        From Enrollments e
        Inner Join Courses c ON e.CourseId = c.CourseId
        Where e.StudentId = @StudentId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StudentId", studentId);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("\nEnrolled Courses for StudentId: " + studentId);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Course Name | Credits | Enroll Date | Grade");

            bool found = false;

            while (dr.Read())
            {
                found = true;

                Console.WriteLine(
                    dr["CourseName"] + " | " +
                    dr["Credits"] + " | " +
                    Convert.ToDateTime(dr["EnrollDate"]).ToShortDateString() + " | " +
                    (dr["Grade"] == DBNull.Value ? "N/A" : dr["Grade"].ToString())
                );
            }

            if (!found)
            {
                Console.WriteLine("No enrollments found for this student.");
            }

            con.Close();
        }
//5th question


        public  void UpdateEnrollments()
        {

            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=adonet;Integrated Security=True";

            int enrollmentId = 101; 
            string grade = "A";     

            
            string query = "Update Enrollments Set Grade = @Grade Where EnrollmentId = @EnrollmentId";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@Grade", grade);
                        command.Parameters.AddWithValue("@EnrollmentId", enrollmentId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Grade updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No record found with the given EnrollmentId.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

    }
}
