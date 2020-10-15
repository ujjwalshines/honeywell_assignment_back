using Assessment.DI;
using Assessment.Interfaces;
using System;

namespace Assessment.GlueService
{
    public class InstanceGenerator : IInstanceGenerator
    {
        public IProductRepository Product { get; set; }
        public ILoginRepository Login { get; set; }
        public InstanceGenerator() => (Product,Login) = (Injector.Inject<IProductRepository>(), Injector.Inject<ILoginRepository>());
    }
}
