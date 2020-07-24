using System;

namespace FactoryTesting
{
    public class Product
    {
        public Guid Id { get; }
        public string Description { get; }

        public Product(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}