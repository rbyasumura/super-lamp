using Advance.Framework.Interfaces.Entities;
using System;

namespace Advance.Framework.Modules.Cms.Entities
{
    public class WebPage : ITimestampableEntity
        , IVersionedEntity
    {
        public Guid WebPageId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public Guid VersionId { get; set; }
        public Guid? PreviousVersionId { get; set; }
    }
}
