using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Contexts;
using Advance.Framework.Repositories.Interfaces;
using System.Collections.Generic;

namespace Advance.Framework.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ContextWrapperBase context;

        public UnitOfWork()
        {
        }

        internal ContextWrapperBase Context
        {
            get
            {
                if (context == null)
                {
                    context = (ContextWrapperBase)Container.Instance.Resolve<IContextWrapper>();
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
            return Context.SaveChangesInternal();
        }
    }
}
