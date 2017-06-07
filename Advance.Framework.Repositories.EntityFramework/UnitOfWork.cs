using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Advance.Framework.Repositories.EntityFramework
{
    [Serializable]
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        private DbContextTransaction transaction;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction = null;
            }
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }

            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }

        public TRepository GetRepository<TRepository>()
        {
            return Container.Instance.Resolve<TRepository>(new Dictionary<string, object>()
            {
                { "unitOfWork", this },
            });
        }

        internal void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        internal int SaveChanges()
        {
            if (transaction == null)
            {
                transaction = context.Database.BeginTransaction();
            }

            var now = DateTimeOffset.Now;

            foreach (var entity in context.ChangeTracker.Entries())
            {
                InterceptSoftDeletableEntity(entity, now);
                InterceptTimestampableEntity(entity, now);
            }

            return context.SaveChanges();
        }

        internal DbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return context.Set<TEntity>();
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
    }
}