using Advance.Framework.Modules.Cms.Entities;
using Advance.Framework.Modules.Cms.Interfaces;
using Advance.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Modules.Cms.Repositories
{
    public class WebPageRepository : Repository
        , IWebPageRepository
    {
        public bool Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public WebPage GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WebPage> ListAll()
        {
            return base.ListAll<WebPage>();
        }

        public IEnumerable<WebPage> ListAll<TProperty>(params Expression<Func<WebPage, TProperty>>[] includes)
        {
            throw new NotImplementedException();
        }
    }
}
