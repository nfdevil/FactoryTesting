using System;

namespace FactoryTesting
{
    public interface IProductProcessor
    {
        void BuyProduct(Guid id);
        Product GetProduct(Guid id);
    }
}