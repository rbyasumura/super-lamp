﻿using Advance.Framework.Contexts.EntityFramework.Wrappers;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Contexts;
using Advance.Framework.Loggers.Interfaces;
using Advance.Framework.Loggers.log4net;
using Advance.Framework.Modules.Core.Interfaces.Repositories;
using Advance.Framework.Modules.Core.Repositories;
using Advance.Framework.Repositories;
using Advance.Framework.Repositories.Interfaces;
using Kendo.Contexts.EntityFramework;
using NUnit.Framework;

namespace Advance.Framework.Modules.Core.UnitTests.Repositories
{
    [SetUpFixture]
    internal class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Container.Instance
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<IPersonRepository, PersonRepository>()
                .RegisterType<ILogger, Log4NetLogger>()
                .RegisterType<IContextWrapper, DbContextWrapper<Context>>()
                .RegisterType<IStateRepository, StateRepository>()
                ;
        }
    }
}
