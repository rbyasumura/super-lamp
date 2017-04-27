﻿using Advance.Framework.ContactModule.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    class ContactModuleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
