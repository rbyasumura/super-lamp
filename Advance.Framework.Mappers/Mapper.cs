using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Mappers.Interfaces;

namespace Advance.Framework.Mappers
{
    public class Mapper
    {
        public static IMapper Instance
        {
            get
            {
                return Container.Instance.Resolve<IMapper>();
            }
        }
    }
}
