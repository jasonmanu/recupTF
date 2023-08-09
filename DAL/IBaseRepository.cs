using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
