using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Framework.PersonService.Entities
{
    public class Person
    {
        public Person()
        {
            PersonId = Guid.NewGuid();
        }

        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
