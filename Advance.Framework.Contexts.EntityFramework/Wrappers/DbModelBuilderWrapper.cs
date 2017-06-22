using Advance.Framework.Interfaces.Repositories;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    public sealed class DbModelBuilderWrapper : IModelBuilder
    {
        private DbModelBuilder modelBuilder;

        public DbModelBuilderWrapper(DbModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public IEntityTypeConfiguration<TEntity> Entity<TEntity>()
            where TEntity : class
        {
            return new EntityTypeConfigurationWrapper<TEntity>(modelBuilder.Entity<TEntity>());
        }
    }
}
