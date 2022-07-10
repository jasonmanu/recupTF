using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        //private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            //this.repository = repository;
        }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            //repository.Delete(id);
        }

        public List<TEntity> GetAll()
        {
            //return repository.GetAll();
            return null;
        }

        public TEntity GetById(int id)
        {
            return null;
            //return repository.GetById(id);
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
