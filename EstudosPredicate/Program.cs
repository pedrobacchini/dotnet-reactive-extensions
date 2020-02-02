using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EstudosReactiveExtensions.Entities;

namespace EstudosPredicate
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
            
            products.FindAll(p => p.Price > 100).ForEach(p => Console.WriteLine(p.ToString()));

//            products.RemoveAll(p => p.Price > 100);
            products.RemoveAll(ProductFilter);
            products.ForEach(p => Console.WriteLine(p.ToString()));
        }

        private static bool ProductFilter(Product product)
        {
            return product.Price >= 100.0;
        }
    }
}