using Advance.Framework.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace Advance.Framework.Security.Entities
{
    public class Role : ITimestampableEntity
        , ISoftDeletableEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public ICollection<User> Users { get; set; }
        private string Name { get; set; }
        private Guid RoleId { get; set; }
    }
}
