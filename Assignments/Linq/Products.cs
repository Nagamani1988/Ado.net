using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    public class Products
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public int price { get; set; }
        public int qty { get; set; }

        // 1. find second highest price
        public void secondhighest(List<Products> li1)
        {
            var secondHighest = li1
                    .OrderByDescending(p => p.price)
                    .Skip(1)
                    .FirstOrDefault();

            Console.WriteLine("Second Highest Price: " + secondHighest.price);
        }
        //2. display top 3 highest price
        public void top3(List<Products> li1)
        {
            var top3 = li1
             .OrderByDescending(p => p.price)
             .Take(3)
             .ToList();

            Console.WriteLine("Top 3 Highest Prices:");
            foreach (var item in top3)
            {
                Console.WriteLine($"{item.pname} - {item.price}");
            }

        }
        //3. find the sum of price where product names contains letter 'O' 
        public void sumofprice(List<Products> li1)
        {
            var sumPriceO = li1
                .Where(p => p.pname.ToLower().Contains("o"))
                .Sum(p => p.price);

            Console.WriteLine("Sum of prices where product name contains 'O' = " + sumPriceO);
        }
        //4.  find the product name ends with e and display only pid and pname (filter by column name)
        public void filterbycolumn(List<Products> li1)
        {
            var result = li1
             .Where(p => p.pname.ToLower().EndsWith("e"))
             .Select(p => new { p.pid, p.pname });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.pid}  {item.pname}");
            }
        }

        //5. group all records by qty find max of price
        public void groupby(List<Products> li1)
        {
            var result = li1
             .GroupBy(p => p.qty)
             .Select(g => new
             {
                 Qty = g.Key,
                 MaxPrice = g.Max(x => x.price)
             });

            foreach (var item in result)
            {
                Console.WriteLine($"Qty: {item.Qty}  →  Max Price: {item.MaxPrice}");
            }
        }
        //Q6. Find sum of price of all products.
        public void sumofProducts(List<Products> li1)
        {
            var totalPrice = li1.Sum(p => p.price);

            Console.WriteLine("Total Sum of Prices = " + totalPrice);

        }
        //Q7. Find count of products where price > 5000.
        public void countofproducts(List<Products> li1)
        {
            var count = li1.Count(p => p.price > 5000);

            Console.WriteLine("Count of products with price > 5000 = " + count);

        }






    }
}
