using Advance.Framework.Modules.Core.Entities;
using Advance.Framework.Modules.Core.Interfaces.Repositories;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Core.Repositories
{
    public class StateRepository : ReadOnlyRepositoryBase<State>
            , IStateRepository
    {
        public StateRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
