using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using LazyCache;

using Microsoft.Extensions.Caching.Memory;

namespace FactoryTesting
{
    public class AzureProductRepository : IAzureProductRepository
    {
        private readonly IAppCache _cache;
        private readonly ICollection<Product> _products;
        private const string CACHE_KEY = "AzureProducts";
        public AzureProductRepository(IAppCache cache)
        {
            _cache = cache;
            _products = new List<Product>
            {
                new Product(Guid.Parse("ac762520-715f-4d6b-a10a-4281ae8e0230"), "Portal"),
                new Product(Guid.Parse("d1e2f7df-ab1e-40f0-beb1-1bbbc1965c0b"), "Azure Service Bus")
            };
        }

        public Product GetProduct(Guid id)
        {
            //return _cache.GetOrAdd($"{CACHE_KEY}-{id}", () => GetAll().FirstOrDefault(x => x.Id == id));
            return _cache.GetOrAdd(CACHE_KEY, () => GetAll()).FirstOrDefault(x => x.Id == id);
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
            _cache.Remove(CACHE_KEY);
        }

        private IQueryable<Product> GetAll()
        {
            Thread.Sleep(2000);
            IReadOnlyList<Product> result = _products.ToList();
            return result.AsQueryable();
        }
    }
}