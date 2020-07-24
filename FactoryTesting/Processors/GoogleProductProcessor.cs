using System;

namespace FactoryTesting
{
    public class GoogleProductProcessor : IProductProcessor
    {
        public GoogleProductProcessor(GoogleService googleService)
        {
            
        }
        public void BuyProduct(Guid id)
        {
        }

        public Product GetProduct(Guid id)
        {
            return new Product(Guid.NewGuid(), "Newest Google Product");
        }

        public void AddProduct(Product product)
        {
        }
    }
}