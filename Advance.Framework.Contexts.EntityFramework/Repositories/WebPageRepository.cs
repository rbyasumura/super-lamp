using Advance.Framework.Modules.Cms.Entities;
using Advance.Framework.Modules.Cms.Interfaces;
using System;
using System.Collections.Generic;

namespace Advance.Framework.Contexts.EntityFramework.Repositories
{
    public class WebPageRepository : IWebPageRepository
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
            throw new NotImplementedException();
        }

        public IEnumerable<WebPage> ListAll<TProperty>(params System.Linq.Expressions.Expression<Func<WebPage, TProperty>>[] includes)
        {
            throw new NotImplementedException();
        }
    }
}
