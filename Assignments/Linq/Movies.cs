using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    public class Movies
    {

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Actor { get; set; }
        public string Actress { get; set; }
        public int YOR { get; set; }


        // 1. display list of movienames acted by prabhas

        public void MoviePrabhas(List<Movies> li)
        {

            var res = from t in li where t.Actor == "Prabhas" select t;

            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }

            Console.WriteLine("\n=======================================\n");
        }

        // 2. display list of all movies released in year 2019

        public void Movie2019(List<Movies> li)
        {
            var res = li.Where(t => t.YOR == 2019);
            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }

            Console.WriteLine("\n=======================================\n");
        }
        
   // 3. display the list of movies who acted together by prabhas and anushka
            public void PrabhasAnushka(List<Movies> li)
            {
                var res = from t in li
                          where t.Actor == "Prabhas" && t.Actress == "Anushka"
                          select t;

                foreach (var item in res)
                {
                    Console.WriteLine($"{item.MovieName}");
                }

                Console.WriteLine("\n=======================================\n");
        }
        // 4. display the list of all actress who acted with prabhas
        
        public void ActressWithPrabhas(List<Movies> li)
        {
            var res = li
                      .Where(t => t.Actor == "Prabhas")
                      .Select(t => t.Actress)
                      .Distinct();   // to avoid duplicates

            foreach (var item in res)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("\n=======================================\n");
        }
        //5. display the list of all moves released from 2010 - 2018
       
        public void Movies2010To2018(List<Movies> li)
        {
            var res = from t in li
                      where t.YOR >= 2010 && t.YOR <= 2018
                      select t;

            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }

            Console.WriteLine("\n=======================================\n");
        }
        //6. sort YOR in descending order and display all its records 
       
        public void SortYORDescending(List<Movies> li)
        {
            var res = from t in li
                      orderby t.YOR descending
                      select t;

            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieId}  {item.MovieName}  {item.Actor}  {item.Actress}  {item.YOR}");
            }

            Console.WriteLine("\n=======================================\n");
        }
        //   7. display max movies acted by each actor
        // 7. display max movies acted by each actor

        public void MaxMoviesByActor(List<Movies> li)
        {
                   var res = li
                      .GroupBy(t => t.Actor)
                      .Select(g => new
                      {
                          Actor = g.Key,
                          Count = g.Count()
                      });

            Console.WriteLine("Movies count by each actor:\n");

            foreach (var item in res)
            {
                Console.WriteLine($"{item.Actor}  --->  {item.Count}");
            }

            Console.WriteLine("\nActor with maximum movies:\n");

           
            var maxActor = res.OrderByDescending(t => t.Count).First();
            Console.WriteLine($"{maxActor.Actor} acted in {maxActor.Count} movies.");
            Console.WriteLine("\n=======================================\n");
        }
        
        // 8. display the name of all movies which is 5 characters long

        public void MovieNameLength5(List<Movies> li)
        {
            var res = from t in li
                      where t.MovieName.Length == 5
                      select t;

            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }

            Console.WriteLine("\n=======================================\n");
        }
        //// 9. display names of actor and actress where movie released in 
        //    year 2017, 2009 and 2019

        public void ActorActressByYear(List<Movies> li)
        {
            int[] years = { 2017, 2009, 2019 };

            var res = from t in li
                      where years.Contains(t.YOR)
                      select new { t.MovieName, t.Actor, t.Actress, t.YOR };

            foreach (var item in res)
            {
                Console.WriteLine($"{item.YOR} - {item.MovieName} - {item.Actor} & {item.Actress}");
            }

            Console.WriteLine("\n=======================================\n");
        }
        //// 10. display the name of movies which start with 'b' and ends with 'i'

        public void MoviesStartBEndI(List<Movies> li)
        {
            var res = from t in li
                      where t.MovieName.ToLower().StartsWith("b")
                         && t.MovieName.ToLower().EndsWith("i")
                      select t;

            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }

            Console.WriteLine("\n=======================================\n");
        }
        //// 11. display name of actress who not acted with Rajini and print in descending order

        public void ActressNotWithRajini(List<Movies> li)
        {
             var actressesWithRajini = li
                                       .Where(t => t.Actor == "Rajini")
                                       .Select(t => t.Actress)
                                       .Distinct();
                var res = li
                      .Where(t => !actressesWithRajini.Contains(t.Actress))
                      .Select(t => t.Actress)
                      .Distinct()
                      .OrderByDescending(a => a);  

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n=======================================\n");
        }
        // 12. display records in the following format
        // movie name     cast
        // Bahubali       Prabhas - Tamanna

        public void DisplayMovieCast(List<Movies> li)
        {
            Console.WriteLine("Movie Name\tCast\n");

            var res = from t in li
                      select new
                      {
                          t.MovieName,
                          Cast = t.Actor + " - " + t.Actress
                      };

            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}\t{item.Cast}");
            }

            Console.WriteLine("\n=======================================\n");
        }








    }
}




