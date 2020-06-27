using System;

namespace FactoryTesting
{
    public class Product
    {
        public Guid Id { get; }
        public string Description { get; }

        public Product(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
        }
    }
}