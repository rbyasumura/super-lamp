using System;

namespace Advance.Framework.Modules.Cms.Entities
{
    public class WebPage
    {
        public Guid WebPageId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
