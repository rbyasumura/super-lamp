using Advance.Framework.Interfaces.Entities;
using System;

namespace Advance.Framework.ContactModule.Entities
{
    public class Person : ITimestampableEntity
        , ISoftDeletableEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid PersonId { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
