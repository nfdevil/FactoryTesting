using System;

namespace FactoryTesting
{
    public class AmazonProductProcessor : IProductProcessor
    {
        public AmazonProductProcessor(IAzureProductRepository azureProductRepository, GoogleService googleService)
        {
            
        }
        public void BuyProduct(Guid id)
        {
        }

        public Product GetProduct(Guid id)
        {
            return new Product("Alexa Client");
        }
    }
}