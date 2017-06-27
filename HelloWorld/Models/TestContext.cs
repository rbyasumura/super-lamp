using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.Restier.Core;
using Microsoft.Restier.Core.Model;
using Microsoft.Restier.Core.Submit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.OData.Builder;

namespace HelloWorld.Models
{
    public class TestContext : ApiBase
    {
        private static readonly List<Blah> blah = new List<Blah>();

        public IQueryable<Blah> Blah
        {
            get
            {
                return blah.AsQueryable();
            }
        }

        protected override IServiceCollection ConfigureApi(IServiceCollection services)
        {
            services.AddService<IModelBuilder, ModelBuilder>();
            services.AddService<IChangeSetItemFilter, ChangeSetItemFilter>();
            return base.ConfigureApi(services);
        }

        private class ModelBuilder : IModelBuilder
        {
            public Task<IEdmModel> GetModelAsync(ModelContext context, CancellationToken cancellationToken)
            {
                var builder = new ODataConventionModelBuilder();
                builder.EntityType<Blah>();
                return Task.FromResult(builder.GetEdmModel());
            }
        }
    }

    internal class ChangeSetItemFilter : IChangeSetItemFilter
    {
        public Task OnChangeSetItemProcessedAsync(SubmitContext context, ChangeSetItem item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task OnChangeSetItemProcessingAsync(SubmitContext context, ChangeSetItem item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
