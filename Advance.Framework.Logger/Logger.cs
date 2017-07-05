using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Loggers.Interfaces;

namespace Advance.Framework.Loggers
{
    public class Logger
    {
        private static ILogger _Instance;

        public static ILogger Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = Container.Instance.Resolve<ILogger>();
                }
                return _Instance;
            }
        }
    }
}
