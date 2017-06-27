using Advance.Framework.Repositories;
using Kendo.Entities;
using Kendo.Interfaces.Repositories;

namespace Kendo.Repositories
{
    public class MemberRepository : RepositoryBase<Member>
        , IMemberRepository
    {
        public MemberRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
