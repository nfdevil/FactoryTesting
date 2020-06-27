using System;
using System.Collections;
using System.Collections.Generic;

namespace FactoryTesting
{
    public class AzureProductProcessor : IProductProcessor
    {
        private readonly ICollection<Product> _boughtProducts = new List<Product>();
        private readonly IAzureProductRepository _azureProductRepository;

        public AzureProductProcessor(IAzureProductRepository azureProductRepository)
        {
            _azureProductRepository = azureProductRepository;
        }
        public void BuyProduct(Guid id)
        {
            Product product = _azureProductRepository.GetProduct(id);
            _boughtProducts.Add(product);
        }

        public Product GetProduct(Guid id)
        {
            return _azureProductRepository.GetProduct(id);
        }
    }
}