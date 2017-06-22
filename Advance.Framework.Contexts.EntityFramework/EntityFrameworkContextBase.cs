using Advance.Framework.Contexts.EntityFramework.Wrappers;
using Advance.Framework.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    public abstract class EntityFrameworkContextBase : DbContext
        , IContext
    {
        private IEnumerable<IModelDefinition> modelDefinitions;

        private IEnumerable<IModelDefinition> ModelDefinitions
        {
            get
            {
                if (modelDefinitions == null)
                {
                    modelDefinitions = new HashSet<IModelDefinition>();
                }
                return modelDefinitions;
            }
        }

        protected abstract void RegisterModels(ICollection<IModelDefinition> modelBuilders);

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var modelDefinition in ModelDefinitions)
            {
                modelDefinition.Build(new DbModelBuilderWrapper(modelBuilder));
            }
        }
    }
}
