using System;
namespace SimpleProductApplication.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }

        public Product() { } // for EF / serializers if needed

        public Product(int id, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required", nameof(name));
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
            Id = id;
            Name = name;
            Price = price;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentOutOfRangeException(nameof(newPrice));
            Price = newPrice;
        }
    }
}