using System;

namespace Advance.Framework.Entities
{
    public interface ITimestampableEntity
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
    }
}