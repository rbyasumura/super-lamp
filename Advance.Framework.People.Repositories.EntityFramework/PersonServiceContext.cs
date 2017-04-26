using Advance.Framework.PersonService.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Framework.PersonService.Repositories.EntityFramework
{
    class PersonServiceContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
