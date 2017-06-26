using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Contacts.Interfaces.Repositories;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Contacts.Repositories
{
    public class PhoneNumberRepository : RepositoryBase<PhoneNumber>
        , IPhoneNumberRepository
    {
        public PhoneNumberRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
