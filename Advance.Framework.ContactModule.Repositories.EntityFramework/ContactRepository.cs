using Advance.Framework.ContactModule.Entities;
using Advance.Framework.Repositories.EntityFramework;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class ContactRepository : Repository<Contact>
        , IContactRepository
    {
        #region Public Constructors

        public ContactRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Public Constructors
    }
}