using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Exercise02.Entities;

// ReSharper disable CommentTypo
/*
 * Fazer um programa para ler os dados (nome, email e salário) de funcionários a partir de
 * um arquivo em formato .csv. Em seguida mostrar, em ordem alfabética, o email dos funcionários
 * cujo salário seja superior a um dado valor fornecido pelo usuário. Mostrar também a soma dos
 * salários dos funcionários cujo nome começa com a letra 'M'.
 */
namespace Exercise02
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Write("Enter full file path: ");
            var path = Console.ReadLine();

            Console.Write("Enter the salary: ");
            var baseSalary = double.Parse(Console.ReadLine() ?? throw new InvalidDataException("Invalid salary"));

            var employees = new List<Employee>();

            using (var streamReader = File.OpenText(path))
            {
                while (!streamReader.EndOfStream)
                {
                    var strings = streamReader.ReadLine()?.Split(",");
                    if (strings == null) continue;
                    var name = strings[0];
                    var email = strings[1];
                    var salary = double.Parse(strings[2], CultureInfo.InvariantCulture);
                    employees.Add(new Employee(name, email, salary));
                }
            }

            Console.WriteLine("Email of people whose salary is more than: " + baseSalary);

            var list = employees
                .Where(e => e.Salary > baseSalary)
                .OrderBy(e => e.Email)
                .Select(e => e.Email).ToList();

            list.ForEach(Console.WriteLine);

            var sum = employees.Where(e => e.Name.StartsWith("M")).Select(p => p.Salary).Sum();

            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum);
        }
    }
}