using System;

namespace FactoryTesting
{
    public interface IAzureProductRepository
    {
        Product GetProduct(Guid id);
        void AddProduct(Product product);
    }
}