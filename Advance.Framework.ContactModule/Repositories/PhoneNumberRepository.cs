using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Contacts.Interfaces.Repositories;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Contacts.Repositories
{
    public class PhoneNumberRepository : Repository<PhoneNumber>
        , IPhoneNumberRepository
    {
        public PhoneNumberRepository(UnitOfWorkBase unitOfWork) : base(unitOfWork)
        {
        }
    }
}
