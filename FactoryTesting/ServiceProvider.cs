using Autofac;

namespace FactoryTesting
{
    public class ServiceProvider
    {
        public static IContainer Container { get; set; }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}