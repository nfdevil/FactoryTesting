using System;

using Autofac;

namespace FactoryTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureContainer();
            IConfiguration configuration = Configuration.LoadConfigFromFile();

            var factory = new ProductProcessorFactory();
            IProductProcessor productProcessor = factory.GetProductProcessor(configuration.ProductType);
            Product product = productProcessor.GetProduct(Guid.NewGuid());

            Console.WriteLine($"Product: {product.Description}");
        }

        private static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AzureProductProcessor>().AsSelf();
            builder.RegisterType<AmazonProductProcessor>().AsSelf();
            builder.RegisterType<GoogleProductProcessor>().AsSelf();
            builder.RegisterType<GoogleService>().AsSelf();
            builder.RegisterType<AzureProductRepository>().As<IAzureProductRepository>();
            IContainer container = builder.Build();
            ServiceProvider.Container = container;
        }
    }
}
