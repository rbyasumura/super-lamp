using Advance.Framework.ContactModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class ContactRepository : Repository<Contact>
        , IContactRepository
    {
        public ContactRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
