using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EstudosReactiveExtensions.Entities;

namespace EstudoComparison
{
    [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
    internal static class Program
    {
        private static void Main()
        {
            var products = new List<Product>();

            products.Add(new Product("TV", 900.0));
            products.Add(new Product("Notebook", 1200.0));
            products.Add(new Product("Tablet", 450.0));

            products.Sort((p1, p2) => string.Compare(p1.Name.ToUpper(), p2.Name.ToUpper(), StringComparison.Ordinal));
            
            products.ForEach(product => Console.WriteLine(product.ToString()));
        }
    }
}