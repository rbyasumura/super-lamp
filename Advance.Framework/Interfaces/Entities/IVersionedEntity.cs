using System;

namespace Advance.Framework.Interfaces.Entities
{
    public interface IVersionedEntity
    {
        Guid VersionId { get; set; }
        Guid? PreviousVersionId { get; set; }
    }
}
