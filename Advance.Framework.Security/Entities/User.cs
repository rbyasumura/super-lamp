using Advance.Framework.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace Advance.Framework.Security.Entities
{
    public class User : ITimestampableEntity
        , ISoftDeletableEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public ICollection<Role> Roles { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        private Guid UserId { get; set; }
        private string Username { get; set; }
    }
}
