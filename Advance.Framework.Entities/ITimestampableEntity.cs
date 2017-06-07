using System;

namespace Advance.Framework.Entities
{
    public interface ITimestampableEntity
    {
        #region Public Properties

        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }

        #endregion Public Properties
    }
}