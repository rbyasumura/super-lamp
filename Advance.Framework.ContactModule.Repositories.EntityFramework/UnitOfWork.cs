﻿using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    [Serializable]
    public class UnitOfWork : IUnitOfWork
    {
        private const string CALL_CONTEXT_DATA_NAME = "_UnitOfWork_";

        private ContactModuleContext ContactModuleContext;
        private DbContextTransaction Transaction;

        public UnitOfWork()
        {
            ContactModuleContext = new ContactModuleContext();

            if (DefaultInstance == null)
            {
                DefaultInstance = this;
            }
        }

        public static UnitOfWork DefaultInstance
        {
            get
            {
                return (UnitOfWork)CallContext.GetData(CALL_CONTEXT_DATA_NAME);
            }
            private set
            {
                CallContext.SetData(CALL_CONTEXT_DATA_NAME, value);
            }
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
            }

            if (ContactModuleContext != null && this != DefaultInstance)
            {
                ContactModuleContext.Dispose();
            }
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
            }
        }

        public TRepository GetRepository<TRepository>()
        {
            return Container.Instance.Resolve<TRepository>(new Dictionary<string, object>()
            {
                { "context", this },
            });
        }
    }
}
