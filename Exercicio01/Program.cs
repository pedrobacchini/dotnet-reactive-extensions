using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using EstudosReactiveExtensions.Entities;

// ReSharper disable CommentTypo
/*
 * Fazer um programa para ler um conjunto de produtos a partir de um arquivo em formato .csv
 * (suponha que exista pelo menos um produto).Em seguida mostrar o preço médio dos produtos.
 * Depois, mostrar os nomes, em ordem decrescente, dos produtos que possuem preço inferior ao preço médio.
 */
namespace Exercicio01
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Write("Enter full file path: ");
            var path = Console.ReadLine();

            var products = new List<Product>();

            using (var streamReader = File.OpenText(path))
            {
                while (!streamReader.EndOfStream)
                {
                    var strings = streamReader.ReadLine()?.Split(",");
                    if (strings == null) continue;
                    var name = strings[0];
                    var price = double.Parse(strings[1], CultureInfo.InvariantCulture);
                    products.Add(new Product(name, price));
                }
            }

            var average = products.Select(p => p.Price).DefaultIfEmpty(0).Average();
            Console.WriteLine("Average price: " + average.ToString("F2"));
            var listOrder = products
                .Where(p => p.Price < average)
                .OrderByDescending(p => p.Name)
                .Select(p => p.Name).ToList();
            
            listOrder.ForEach(Console.WriteLine);
        }
    }
}