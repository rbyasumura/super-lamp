using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;
using System.Collections.Generic;

namespace Advance.Framework.Contexts.EntityFramework
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private Context Context;

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
            return Context.Set<TEntity>();
        }

        public override TRepository GetRepository<TRepository>()
        {
            return Container.Instance.Resolve<TRepository>(new Dictionary<string, object>{
                { "unitOfWork", this},
            });
        }
    }
}
