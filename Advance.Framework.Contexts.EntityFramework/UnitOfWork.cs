using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;
using System.Collections.Generic;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private Context Context = new Context();

        public override int Commit()
        {
            return Context.SaveChanges();
        }

        public override void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        protected override IEnumerable<TEntity> Entities<TEntity>()
        {
            return GetSet<TEntity>();
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

        private DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>();
        }
    }
}
