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
            DisConnectedArchitecture ob = new DisConnectedArchitecture();
            ob.PrintTable();
            ob.Credits();
            ob.Courses();
            ob.StudentDelete();
            ob.GetCoueses();
            Console.ReadLine();
        }

    }
}

