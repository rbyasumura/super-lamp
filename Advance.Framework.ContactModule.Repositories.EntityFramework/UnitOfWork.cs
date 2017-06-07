using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Entities;
using Advance.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    [Serializable]
    public class UnitOfWork : IUnitOfWork
    {
        private ContactModuleContext Context;
        private DbContextTransaction Transaction;

        public UnitOfWork()
        {
            Context = new ContactModuleContext();
        }

        internal int SaveChanges()
        {
            if (Transaction == null)
            {
                Transaction = Context.Database.BeginTransaction();
            }

            var now = DateTimeOffset.Now;

            foreach (var entity in Context.ChangeTracker.Entries())
            {
                InterceptSoftDeletableEntity(entity, now);
                InterceptTimestampableEntity(entity, now);
            }

            return Context.SaveChanges();
        }

        private static void InterceptTimestampableEntity(DbEntityEntry entity, DateTimeOffset? timestamp = null)
        {
            var _timestamp = timestamp ?? DateTimeOffset.Now;
            var entityType = entity.Entity.GetType();

            if (typeof(ITimestampableEntity).IsAssignableFrom(entityType))
            {
                var timestampableEntity = (ITimestampableEntity)entity.Entity;
                if (entity.State == EntityState.Added)
                {
                    timestampableEntity.CreatedAt = _timestamp;
                }
                else if (entity.State == EntityState.Modified)
                {
                    timestampableEntity.UpdatedAt = _timestamp;
                }
            }
        }

        private static void InterceptSoftDeletableEntity(DbEntityEntry entity, DateTimeOffset? timestamp = null)
        {
            var _timestamp = timestamp ?? DateTimeOffset.Now;
            var entityType = entity.Entity.GetType();

            if (typeof(ISoftDeletableEntity).IsAssignableFrom(entityType))
            {
                var softDeletableEntity = (ISoftDeletableEntity)entity.Entity;
                if (entity.State == EntityState.Deleted)
                {
                    softDeletableEntity.DeletedAt = _timestamp;
                    entity.State = EntityState.Modified;
                }
            }
        }

        internal DbQuery<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return Context
                .Set<TEntity>()
                .AsNoTracking();
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }

            if (Context != null)
            {
                Context.Dispose();
                Context = null;
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
            Context.Entry(entity).Collection(propertyName).Load();
        }

        internal void EagerLoadReference<TEntity>(TEntity entity, string propertyName) where TEntity : class
        {
            Context.Entry(entity).Reference(propertyName).Load();
        }
    }
}
