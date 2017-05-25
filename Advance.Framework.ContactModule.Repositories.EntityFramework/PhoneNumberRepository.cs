﻿using Advance.Framework.ContactModule.Entities;

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
