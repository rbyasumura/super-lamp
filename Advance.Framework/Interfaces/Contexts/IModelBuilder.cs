using Advance.Framework.Interfaces.Contexts.ModelConfiguration;

namespace Advance.Framework.Interfaces.Contexts
{
    public interface IModelBuilder
    {
        IEntityTypeConfiguration<TEntity> Entity<TEntity>()
            where TEntity : class;
    }
}
