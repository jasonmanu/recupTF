using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBaseService<TEntity> where TEntity : Entity
    {
        void Create(TEntity entity);
        void Delete(string id);
        List<TEntity> GetAll();
        TEntity GetById(string id);
        void Update(TEntity entity);
    }
}
