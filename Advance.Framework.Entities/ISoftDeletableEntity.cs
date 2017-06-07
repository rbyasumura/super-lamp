using System;

namespace Advance.Framework.Entities
{
    public interface ISoftDeletableEntity
    {
        #region Public Properties

        DateTimeOffset? DeletedAt { get; set; }

        #endregion Public Properties
    }
}