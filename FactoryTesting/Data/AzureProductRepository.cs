using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FactoryTesting
{
    public class AzureProductRepository : IAzureProductRepository
    {
        private IEnumerable<Product> _products;
        public AzureProductRepository()
        {
            _products = new List<Product>
            {
                new Product("Portal"),
                new Product("Azure Service Bus")
            };
        }

        public Product GetProduct(Guid id)
        {
            return _products.SingleOrDefault(x => x.Id == id);
        }
    }
}