using Advance.Framework.Contexts.EntityFramework.Wrappers;
using Advance.Framework.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    public abstract class EntityFrameworkContextBase : DbContext
    {
        private ICollection<IModelDefinition> modelDefinitions;

        protected EntityFrameworkContextBase(string connectionString)
                    : base(connectionString)
        {
            RegisterModels(ModelDefinitions);
        }

        /// <summary>
        /// Hide parameterless constructor so that inheriting classes cannot call it
        /// </summary>
        private EntityFrameworkContextBase()
        {
        }

        private ICollection<IModelDefinition> ModelDefinitions
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var modelDefinition in ModelDefinitions)
            {
                modelDefinition.Build(new DbModelBuilderWrapper(modelBuilder));
            }
        }

        protected abstract void RegisterModels(ICollection<IModelDefinition> modelDefinitions);
    }
}
