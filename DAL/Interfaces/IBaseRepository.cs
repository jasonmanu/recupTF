using Entities;
using System.Collections.Generic;

namespace DAL
{
    public interface IBaseRepository<TEntity> where TEntity: Entity
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(string id);
        List<TEntity> GetAll();
        TEntity GetById(string id);
    }
}
