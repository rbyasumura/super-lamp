using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.DependencyInjection.Unity
{
    public class Container
    {
        private static Container _Instance;
        private IUnityContainer unityContainer;

        private Container()
        {
            unityContainer = new UnityContainer();

            /// Try to open config
            try
            {
                unityContainer = unityContainer.LoadConfiguration();
            }
            catch (ArgumentException)
            {
                /// Do nothing
            }
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
            unityContainer.RegisterInstance(instance);

            return this;
        }

        public Container RegisterType<TFrom, TTo>()
            where TTo : TFrom
        {
            unityContainer.RegisterType<TFrom, TTo>();

            return this;
        }

        public T Resolve<T>()
        {
            return Resolve<T>(new Dictionary<string, object>());
        }

        public T Resolve<T>(IDictionary<string, object> parameters)
        {
            return unityContainer.Resolve<T>(parameters.Select(i => new ParameterOverride(i.Key, i.Value)).ToArray());
        }
    }
}
