using Advance.Framework.Modules.Cms.Entities;
using Advance.Framework.Modules.Cms.Interfaces.Repositories;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Cms.Repositories
{
    public class WebPageRepository : RepositoryBase<WebPage>
        , IWebPageRepository
    {
        public WebPageRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
