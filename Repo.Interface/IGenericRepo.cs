using Model;
using System;
using System.Collections.Generic;

namespace Repo.Interface
{
    public interface IGenericRepo<TKey, TEntity>
        where TEntity : BaseModel
    {
        TEntity Get(TKey id);
        IList<TEntity> GetAll();
        IList<TEntity> Create(IList<TEntity> entities);
        TKey Create(TEntity entity);

        void Delete(TKey id);

        TEntity Edit(TEntity entity);
    }
}
