using Rrhh.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrhh.Repository.Base
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        TEntity Add(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        void Delete(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
