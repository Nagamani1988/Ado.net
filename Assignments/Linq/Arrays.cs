using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    public class Arrays
    {

        //Q1. Write a LINQ query to fetch unique values from listA. 
        //Expected Output: 10, 20, 30, 40, 50
        public void fetchvalues(List<int> listA)
        {
            var result = listA.Distinct();

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
            //Q2. Combine values from listA and listB without duplicates.
        public void combine(List<int> listA,List<int> listB)
        {

            var result = listA.Union(listB);

            foreach (var item in result)
            {


                Console.Write(item + " ");
            }

        }
        // Q3. Find items common in listA and listB.
        public void common(List<int> listA,List<int> listB)
        {
            var result = listA.Intersect(listB);

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }

        }
        //Q4. Find names present in names1 but not in names2.
        public void names(List<string> names1, List<string> names2)
        {
            var result = names1.Except(names2);

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }

        }
        //q5. Find the highest value in listA.
        public void highestvalue(List<int> listA)
        {
            var highest = listA.Max();

            Console.WriteLine("Highest value in listA = " + highest);

        }

        //Q8. Write a LINQ query to find numbers divisible by 3 
        //int[] numbers = { 1, 4, 9, 16, 25, 36 };
        public void Numbers(List<int> listA, List<int> listB)
        {
            var result = listA.Where(n => n % 3 == 0);

            foreach (var n in result)
            {
                Console.Write(n + " ");
            }

        }
        //Q9. Write a Linq to query to sort based on string Length 
        //string[] st = { "India", "Srilanka", "canada", "Singapore" };
        public void stringlength(List<string> names1, List<string> names2)
        {
            var result = names1.OrderBy(s => s.Length);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

    }


}
