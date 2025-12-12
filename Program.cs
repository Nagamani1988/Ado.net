using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentOnAdo.net
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ConnectedArchitecture ob = new ConnectedArchitecture();
            //ob.DisplayAllCourses();


            /*Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();

            Console.Write("Enter Year Of Study: ");
            int year = int.Parse(Console.ReadLine());

            ConnectedArchitecture ob = new ConnectedArchitecture();
            ob.AddStudent(name, email, dept, year);*/


            //Console.Write("Enter Department to Search: ");
           // string dept = Console.ReadLine();
           // ConnectedArchitecture ob = new ConnectedArchitecture();
           // ob.SearchStudentsByDepartment(dept);


           
            Console.Write("Enter StudentId: ");
            int sid = int.Parse(Console.ReadLine());
            
            ob.DisplayEnrolledCourses(sid);
          


            Console.ReadLine();
        }





    }
}



    
    

