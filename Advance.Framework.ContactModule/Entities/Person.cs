using Advance.Framework.Entities;
using System;

namespace Advance.Framework.ContactModule.Entities
{
    public class Person : ITimestampableEntity
        , ISoftDeletableEntity
    {
        #region Public Constructors

        public Person()
        {
            PersonId = Guid.NewGuid();
        }

        #endregion Public Constructors

        #region Public Properties

        public DateTimeOffset CreatedAt { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid PersonId { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        #endregion Public Properties
    }
}