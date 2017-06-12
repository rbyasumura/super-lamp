using System;

namespace Advance.Framework.Entities
{
    public interface ISoftDeletableEntity
    {
        DateTimeOffset? DeletedAt { get; set; }
    }
}
