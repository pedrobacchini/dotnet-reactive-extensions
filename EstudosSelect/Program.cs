using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EstudosReactiveExtensions.Entities;

namespace EstudosSelect
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

            var result = products.Select(p => p.Name.ToUpper()).ToList();

            products.ForEach(Console.WriteLine);
            result.ForEach(Console.WriteLine);
        }
    }
}