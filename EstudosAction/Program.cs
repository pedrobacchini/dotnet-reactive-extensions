using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EstudosReactiveExtensions.Entities;

namespace EstudosAction
{
    [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
    internal static class Program
    {
        private static void Main()
        {
            var products = new List<Product>();
            
            products.Add(new Product("TV", 900.0));
            products.Add(new Product("Mouse", 50.0));
            products.Add(new Product("Table", 350.50));
            products.Add(new Product("HD Case", 80.90));

            void Act(Product p) => p.Price *= 1.1;

//            products.ForEach(p => p.Price *= 1.1);
            products.ForEach(Act);
            products.ForEach(Console.WriteLine);

        }

        private static void UpdatePrice(Product p)
        {
            p.Price *= 1.1;
        }
    }
}