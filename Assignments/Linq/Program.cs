using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Movies> li = new List<Movies>()
    {
        new Movies(){ MovieId=100, MovieName="Bahubali", Actor="Prabhas",
Actress="Tamanna", YOR=2015 },
        new Movies(){ MovieId=200, MovieName="Bahubali2", Actor="Prabhas",
Actress="Anushka", YOR=2017 },
        new Movies(){ MovieId=300, MovieName="Robot", Actor="Rajini",
Actress="Aish", YOR=2010 },
        new Movies(){ MovieId=400, MovieName="3 idiots", Actor="Amir",
Actress="kareena", YOR=2009 },
        new Movies(){ MovieId=500, MovieName="Saaho", Actor="Prabhas",
Actress="shraddha", YOR=2019 },
    };

            List<Products> li1 = new List<Products>()
            {
               new Products() { pid = 100, pname = "book", price = 1000, qty = 5 },
                new Products() { pid = 200, pname = "cd", price = 2000, qty = 6 },
                new Products() { pid = 300, pname = "toys", price = 3000, qty = 5 },
                  new Products() { pid = 400, pname = "mobile", price = 8000, qty = 6 },
                new Products() { pid = 600, pname = "pen", price = 200, qty = 7 },
                new Products() { pid = 700, pname = "tv", price = 30000, qty = 7 },
             };

            List<int> listA = new List<int> { 10, 20, 30, 40, 50, 20, 30 };
            List<int> listB = new List<int> { 30, 40, 50, 60, 70, 40 };

            List<string> names1 = new List<string> { "Akshay", "Aasritha", "Deepa", "Kiran",
"Kiran" };
            List<string> names2 = new List<string> { "Kiran", "Manikanta", "Deepa", "Naveen"
};




            Movies movie = new Movies();
            // movie.MoviePrabhas(li);
            // movie.Movie2019(li);
            // movie.PrabhasAnushka(li);
            // movie.ActressWithPrabhas(li);
            // movie.Movies2010To2018(li);
            // movie.SortYORDescending(li);
            //movie.MaxMoviesByActor(li);
            //movie.MovieNameLength5(li);
           // movie.ActorActressByYear(li);
           // movie.MoviesStartBEndI(li);
           // movie.ActressNotWithRajini(li);
            //movie.DisplayMovieCast(li);

            Products product = new Products();
            // product.secondhighest(li1);
            //product.top3(li1);
            //product.sumofprice(li1);
            //product.filterbycolumn(li1);
            //product.groupby(li1);
            //product.sumofProducts(li1);
            //product.countofproducts(li1);

            Arrays array = new Arrays();
            //array.fetchvalues(listA);
            //array.combine(listA,listB);
            //array.common(listA,listB);
            //array.names(names1,names2);
            //array.Numbers(listA, listB);
            //array.highestvalue(listA);
            array.stringlength(names1, names2);
        }
    }
}

