using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace EstudosReactiveExtensions.Entities
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class Product
    {
        public string Name { get; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name + ", " + Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}