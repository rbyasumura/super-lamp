using Advance.Framework.Entities;
using System;
using System.Collections.Generic;

namespace Advance.Framework.ContactModule.Entities
{
    public class Contact : ITimestampableEntity
        , ISoftDeletableEntity
    {
        #region Public Constructors

        public Contact()
        {
            ContactId = Guid.NewGuid();
        }

        #endregion Public Constructors

        #region Public Properties

        public Guid ContactId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public Person Person { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        #endregion Public Properties
    }
}