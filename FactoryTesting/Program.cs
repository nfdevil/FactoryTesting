using System;

using Autofac;

using LazyCache;
using LazyCache.Providers;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

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
            var azureProduct = new Product(Guid.Parse("0258d3bc-1d98-4c2b-a3c6-2b41fadce484"),"SQL Server Database");
            Console.WriteLine("Preload cache...");
            productProcessor.GetProduct(Guid.NewGuid());

            Console.WriteLine("First item from Get:");
            Product product = productProcessor.GetProduct(Guid.Parse("ac762520-715f-4d6b-a10a-4281ae8e0230"));
            Console.WriteLine($"Product: {product.Description}");
            Console.WriteLine("Cached item:");
            product = productProcessor.GetProduct(Guid.Parse("d1e2f7df-ab1e-40f0-beb1-1bbbc1965c0b"));
            Console.WriteLine($"Product: {product.Description}");

            productProcessor.AddProduct(azureProduct);
            Console.WriteLine("Refreshing cache...");
            product = productProcessor.GetProduct(azureProduct.Id);
            Console.WriteLine("New item:");
            Console.WriteLine($"Product: {product.Description}");
        }

        private static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AzureProductProcessor>().AsSelf();
            builder.RegisterType<AmazonProductProcessor>().AsSelf();
            builder.RegisterType<GoogleProductProcessor>().AsSelf();
            builder.RegisterType<GoogleService>().AsSelf();
            builder.Register(c => new CachingService(new Lazy<ICacheProvider>(c.Resolve<ICacheProvider>()))).As<IAppCache>().SingleInstance();
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
            builder.RegisterType<MemoryCacheProvider>().As<ICacheProvider>().SingleInstance();
            builder.Register(c => Options.Create(new MemoryCacheOptions())).As<IOptions<MemoryCacheOptions>>();
            builder.RegisterType<AzureProductRepository>().As<IAzureProductRepository>();
            IContainer container = builder.Build();
            ServiceProvider.Container = container;
        }
    }
}
