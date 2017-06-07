using Advance.Framework.ContactModule.Entities;
using Advance.Framework.Repositories.EntityFramework;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class PhoneNumberRepository : Repository<PhoneNumber>
        , IPhoneNumberRepository
    {
        public PhoneNumberRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}