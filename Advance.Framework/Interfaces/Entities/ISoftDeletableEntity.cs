using System;

namespace Advance.Framework.Interfaces.Entities
{
    public interface ISoftDeletableEntity
    {
        DateTimeOffset? DeletedAt { get; set; }
    }
}
