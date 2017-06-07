using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.DependencyInjection.Unity
{
    public class Container
    {
        #region Private Fields

        private static Container _Instance;
        private UnityContainer UnityContainer;

        #endregion Private Fields

        #region Private Constructors

        private Container()
        {
            UnityContainer = new UnityContainer();
        }

        #endregion Private Constructors

        #region Public Properties

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

        #endregion Public Properties

        #region Public Methods

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

        #endregion Public Methods
    }
}