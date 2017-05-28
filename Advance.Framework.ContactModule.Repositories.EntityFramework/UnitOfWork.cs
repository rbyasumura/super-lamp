using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    [Serializable]
    public class UnitOfWork : IUnitOfWork
    {
        private ContactModuleContext ContactModuleContext;
        private DbContextTransaction Transaction;

        public UnitOfWork()
        {
            ContactModuleContext = new ContactModuleContext();
        }

        internal int SaveChanges()
        {
            if (Transaction == null)
            {
                Transaction = ContactModuleContext.Database.BeginTransaction();
            }

            return ContactModuleContext.SaveChanges();
        }

        internal DbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return ContactModuleContext.Set<TEntity>();
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }

            if (ContactModuleContext != null)
            {
                ContactModuleContext.Dispose();
                ContactModuleContext = null;
            }
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction = null;
            }
        }

        public TRepository GetRepository<TRepository>()
        {
            return Container.Instance.Resolve<TRepository>(new Dictionary<string, object>()
            {
                { "unitOfWork", this },
            });
        }

        internal void EagerLoadCollection<TEntity>(TEntity entity, string propertyName) where TEntity : class
        {
            ContactModuleContext.Entry(entity).Collection(propertyName).Load();
        }

        internal void EagerLoadReference<TEntity>(TEntity entity, string propertyName) where TEntity : class
        {
            ContactModuleContext.Entry(entity).Reference(propertyName).Load();
        }
    }
}
