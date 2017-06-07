using Advance.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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