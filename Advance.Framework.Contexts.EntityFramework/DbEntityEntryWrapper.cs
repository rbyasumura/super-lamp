﻿using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories;
using System.Data.Entity.Infrastructure;

namespace Advance.Framework.Contexts.EntityFramework
{
    internal class DbEntityEntryWrapper : IChangedEntry
    {
        private DbEntityEntry entityEntry;

        public DbEntityEntryWrapper(DbEntityEntry entityEntry)
        {
            this.entityEntry = entityEntry;
        }

        public object Entity => entityEntry.Entity;
        public EntityState State => (EntityState)entityEntry.State;
    }
}
