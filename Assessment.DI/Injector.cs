using Assessment.Interfaces;
using Assessment.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.DI
{
    public class Injector
    {
        public static dynamic Inject<T>(params object[] parameters) => Resolve<T>(parameters);
        private static dynamic Resolve<T>(params object[] parameters) =>
            (typeof(T) == typeof(IProductRepository)) ?
                Instanciate<IProductRepository, ProductRepository>(parameters):
             (typeof(T) == typeof(ILoginRepository)) ?
                Instanciate<ILoginRepository, LoginRepository>(parameters)
            :
            null;
        private static dynamic Instanciate<TInterface, TClass>(params object[] parameters) =>
            (typeof(TInterface).IsAssignableFrom(typeof(TClass))) ?
                    (parameters == null) ? Activator.CreateInstance<TClass>() :
                        Activator.CreateInstance(typeof(TClass), parameters)
                    : null;
    }
}
