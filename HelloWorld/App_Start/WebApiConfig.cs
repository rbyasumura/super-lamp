using HelloWorld.Models;
using Microsoft.Restier.Providers.EntityFramework;
using Microsoft.Restier.Publishers.OData;
using Microsoft.Restier.Publishers.OData.Batch;
using System.Web.Http;

namespace HelloWorld
{
    public static class WebApiConfig
    {
        public async static void Register(HttpConfiguration config)
        {
            await config.MapRestierRoute<EntityFrameworkApi<AdventureWorksLT>>(
                "AdventureWorksLT",
                "api/AdventureWorksLT",
                new RestierBatchHandler(GlobalConfiguration.DefaultServer));

            await config.MapRestierRoute<TestContext>(
               "Test",
               "api/Test",
               new RestierBatchHandler(GlobalConfiguration.DefaultServer));
        }
    }
}
