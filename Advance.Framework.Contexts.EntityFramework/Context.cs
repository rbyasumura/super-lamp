using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using System;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    public partial class Context : DbContext
        , IUnitOfWork
    {
        public Context()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public TRepository GetRepository<TRepository>()
        {
            return Container.Instance.Resolve<TRepository>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureContact(modelBuilder);
            ConfigureSecurity(modelBuilder);
            ConfigureCms(modelBuilder);
        }
    }
}
