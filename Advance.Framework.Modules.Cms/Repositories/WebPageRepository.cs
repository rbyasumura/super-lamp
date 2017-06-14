﻿using Advance.Framework.Modules.Cms.Entities;
using Advance.Framework.Modules.Cms.Interfaces;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Cms.Repositories
{
    public class WebPageRepository : Repository<WebPage>
        , IWebPageRepository
    {
        public WebPageRepository(UnitOfWorkBase unitOfWork) : base(unitOfWork)
        {
        }
    }
}