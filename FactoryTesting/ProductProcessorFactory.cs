using System;

namespace FactoryTesting
{
    public class ProductProcessorFactory
    {
        public IProductProcessor GetProductProcessor(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Azure:
                case ProductType.AzureMicrosoft:
                case ProductType.AzurePortal:
                    return ServiceProvider.Resolve<AzureProductProcessor>();
                case ProductType.Aws:
                    return ServiceProvider.Resolve<AmazonProductProcessor>();
                case ProductType.Firebase:
                case ProductType.GooglePlatform:
                    return ServiceProvider.Resolve<GoogleProductProcessor>();
                default:
                    throw new ArgumentException(nameof(productType));
            }
        }
    }
}