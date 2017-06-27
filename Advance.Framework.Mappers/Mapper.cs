using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Mappers;
using System;
using System.Linq;

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
