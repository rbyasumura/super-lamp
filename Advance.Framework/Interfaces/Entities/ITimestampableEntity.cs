using System;

namespace Advance.Framework.Interfaces.Entities
{
    public interface ITimestampableEntity
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
    }
}
