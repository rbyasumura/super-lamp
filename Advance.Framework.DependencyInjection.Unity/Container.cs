using Advance.Framework.ContactModule.Repositories;
using Advance.Framework.ContactModule.Repositories.EntityFramework;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Framework.DependencyInjection.Unity
{
    public class Container
    {
        private UnityContainer UnityContainer;
        private static Container _Instance;

        Container()
        {
            UnityContainer = new UnityContainer();
            UnityContainer
                .RegisterType<IPersonRepository, PersonRepository>()
                .RegisterType<IUnitOfWork, UnitOfWork>()
                ;
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

        public T Resolve<T>()
        {
            return UnityContainer.Resolve<T>();
        }
    }
}
