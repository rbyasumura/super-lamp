using Advance.Framework.ContactModule.Entities;
using Advance.Framework.Repositories.EntityFramework;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class PhoneNumberRepository : Repository<PhoneNumber>
        , IPhoneNumberRepository
    {
        #region Public Constructors

        public PhoneNumberRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Public Constructors
    }
}