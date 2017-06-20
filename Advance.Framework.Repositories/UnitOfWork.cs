using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using System.Collections.Generic;

namespace Advance.Framework.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ContextWrapper context;

        public UnitOfWork()
        {
        }

        internal ContextWrapper Context
        {
            get
            {
                if (context == null)
                {
                    context = (ContextWrapper)Container.Instance.Resolve<IContextWrapper>();
                }
                return context;
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        public TRepository GetRepository<TRepository>()
        {
            return Container.Instance.Resolve<TRepository>(new Dictionary<string, object>{
                { "unitOfWork", this},
            });
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
