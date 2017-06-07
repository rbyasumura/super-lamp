using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.DependencyInjection.Unity
{
    public class Container
    {
        private static Container _Instance;
        private UnityContainer UnityContainer;

        private Container()
        {
            UnityContainer = new UnityContainer();
        }

        public static Container Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Container();
                }

                return _Instance;
            }
        }

        public Container RegisterInstance<TInterface>(TInterface instance)
        {
            //UnityContainer.RegisterInstance(instance, new ContainerControlledLifetimeManager());
            //UnityContainer.RegisterInstance(instance, new ExternallyControlledLifetimeManager());
            UnityContainer.RegisterInstance<TInterface>(instance);

            return this;
        }

        public Container RegisterType<TFrom, TTo>()
            where TTo : TFrom
        {
            UnityContainer.RegisterType<TFrom, TTo>();

            return this;
        }

        public T Resolve<T>()
        {
            return Resolve<T>(new Dictionary<string, object>());
        }

        public T Resolve<T>(IDictionary<string, object> parameters)
        {
            return UnityContainer.Resolve<T>(parameters.Select(i => new ParameterOverride(i.Key, i.Value)).ToArray());
        }
    }
}