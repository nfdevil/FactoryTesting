namespace FactoryTesting
{
    public class Configuration : IConfiguration
    {
        public Configuration(ProductType productType)
        {
            ProductType = productType;
        }
        public ProductType ProductType { get; }
        public static IConfiguration LoadConfigFromFile()
        {
            ProductType productTypeFromFile = ProductTypeFromFile();
            return new Configuration(productTypeFromFile); 
        }

        private static ProductType ProductTypeFromFile()
            => ProductType.Azure;
    }
}