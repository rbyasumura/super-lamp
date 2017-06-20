﻿using Advance.Framework.Security.Entities;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    partial class EntityFrameworkContext
    {
        private void ConfigureSecurity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Role>();
        }
    }
}