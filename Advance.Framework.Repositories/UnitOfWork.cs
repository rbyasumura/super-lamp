using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories.Extensions.System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
                    context = (ContextWrapper)Container.Instance.Resolve<IContext>();
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

        internal IQueryable<TEntity> Entities<TEntity, TProperty>(params Expression<Func<TEntity, TProperty>>[] includes) where TEntity : class
        {
            var queryable = Context.GetSet<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                queryable = queryable.Include(include);
            }
            return queryable;
        }
    }
}
