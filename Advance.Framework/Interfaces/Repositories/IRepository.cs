﻿namespace Advance.Framework.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}
