using System;
using System.Collections.Generic;
using System.Linq;
using EstudosLinq.Entities;

namespace EstudosLinq
{
    internal static class Program
    {
        private static void Main()
        {
            var c1 = new Category {Id = 1, Name = "Tools", Tier = 2};
            var c2 = new Category {Id = 2, Name = "Computer", Tier = 1};
            var c3 = new Category {Id = 3, Name = "Electronics", Tier = 1};

            var products = new List<Product>
            {
                new Product {Id = 1, Name = "Computer", Price = 1100.0, Category = c2},
                new Product {Id = 2, Name = "Hammer", Price = 90.0, Category = c1},
                new Product {Id = 3, Name = "TV", Price = 1700.0, Category = c3},
                new Product {Id = 4, Name = "Notebook", Price = 1300.0, Category = c2},
                new Product {Id = 5, Name = "Saw", Price = 80, Category = c1},
                new Product {Id = 6, Name = "Tablet", Price = 700.0, Category = c2},
                new Product {Id = 7, Name = "Camera", Price = 700.0, Category = c3},
                new Product {Id = 8, Name = "Printer", Price = 350.0, Category = c3},
                new Product {Id = 9, Name = "MacBook", Price = 1800.0, Category = c2},
                new Product {Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3},
                new Product {Id = 11, Name = "Level", Price = 70.0, Category = c1}
            };

//            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900);
            var r1 =
                from p in products
                where p.Category.Tier == 1 && p.Price < 900
                select p;
            Print("PRODUCTS TIER 1 AND PRICE < 900", r1);

//            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            var r2 =
                from p in products
                where p.Category.Name == "Tools"
                select p.Name;
            Print("NAMES OF PRODUCTS FROM TOOLS", r2);

//            var r3 = products.Where(p => p.Name.StartsWith("C"))
//                .Select(p => new {p.Name, p.Price, CategoryName = p.Category.Name});
            var r3 =
                from p in products
                where p.Name.StartsWith("C")
                select new
                {
                    p.Name,
                    p.Price,
                    CategoryName = p.Category.Name
                };
            Print("PRODUCTS WITH NAME START C", r3);

//            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            var r4 = from p in products
                where p.Category.Tier == 1
                orderby p.Price, p.Name
                select p;
            Print("PRODUCTS TIER 1 ORDER BY PRICE", r4);


//            var r5 = r4.Skip(2).Take(4);
            var r5 = (from p in r4 select p).Skip(2).Take(4);
            Print("PRODUCTS TIER 1 ORDER BY PRICE SKIP 2 TAKE 4", r5);

//            var r6 = products.FirstOrDefault();
            var r6 = (from p in products select p).FirstOrDefault();
            Console.WriteLine("First or default test1: " + r6);

//            var r7 = products.FirstOrDefault(p => p.Price > 3000);
            var r7 = (from p in products select p).FirstOrDefault(p => p.Price > 3000);
            Console.WriteLine("First or default test2: " + r7);
            Console.WriteLine();

            var r8 = products.SingleOrDefault(p => p.Id == 3);
            Console.WriteLine("Single or default: " + r8);
            var r9 = products.SingleOrDefault(p => p.Id == 30);
            Console.WriteLine("Single or default: " + r9);
            Console.WriteLine();

            var r10 = products.Max(p => p.Price);
            Console.WriteLine("Max Price: " + r10);

            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Max Price: " + r11);

            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 Sum prices: " + r12);

            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("Category 1 Average prices: " + r13);

            var r14 = products.Where(p => p.Category.Id == 4).Select(p => p.Price).DefaultIfEmpty(0).Average();
            Console.WriteLine("Category 5 Average prices: " + r14);

            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate((p1, p2) => p1 + p2);
            Console.WriteLine("Category 1 Aggregate Sum prices: " + r15);

            var r16 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).Aggregate(0.0, (p1, p2) => p1 + p2);
            Console.WriteLine("Category 5 Aggregate Sum prices: " + r16);
            Console.WriteLine();

//            var r17 = products.GroupBy(p => p.Category);
            var r17 = from p in products group p by p.Category;
            foreach (var group in r17)
            {
                Console.WriteLine(group.Key.Name);
                group.ToList().ForEach(Console.WriteLine);
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void Print<T>(string message, IEnumerable<T> enumerable)
        {
            Console.WriteLine(message);
            foreach (var value in enumerable)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
        }
    }
}