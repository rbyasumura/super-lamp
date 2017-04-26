using Advance.Framework.PersonService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advance.Framework.PersonService.Entities;
using Advance.Framework.PersonService.Repositories.EntityFramework;
using AutoMapper;

namespace Advance.Framework.People.Repositories.EntityFramework
{
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository()
        {
        }

        public void Add(Person person)
        {
            using (var context = GetContext())
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }

        public void Delete(Person person)
        {
            using (var context = GetContext())
            {
                var _person = context.People.Single(i => i.PersonId == person.PersonId);
                context.People.Remove(_person);
                context.SaveChanges();
            }
        }

        public Person GetById(Guid id)
        {
            using (var context = GetContext())
            {
                return context.People.SingleOrDefault(i => i.PersonId == id);
            }
        }

        public IEnumerable<Person> ListAll()
        {
            using (var context = GetContext())
            {
                return context.People.ToArray();
            }
        }

        private static PersonServiceContext GetContext()
        {
            return new PersonServiceContext();
        }

        public void Update(Person person)
        {
            using (var context = GetContext())
            {
                var _person = context.People.Single(i => i.PersonId == person.PersonId);
                Mapper.Map(person, _person);

                context.SaveChanges();
            }
        }
    }
}
