using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories;
using System.Collections.Generic;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private Context context = new Context();

        protected override IContext Context => context;

        public override void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public override TRepository GetRepository<TRepository>()
        {
            return Container.Instance.Resolve<TRepository>(new Dictionary<string, object>{
                { "unitOfWork", this},
            });
        }

        protected override TEntity Add<TEntity>(TEntity entity)
        {
            return GetSet<TEntity>().Add(entity);
        }

        protected override IEnumerable<TEntity> Entities<TEntity>()
        {
            return GetSet<TEntity>();
        }

        private DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }
    }
}
