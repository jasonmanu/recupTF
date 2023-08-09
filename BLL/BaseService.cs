using DAL;
using Entities;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Create(TEntity entity)
        {
            repository.Create(entity);
        }

        public virtual void Delete(string id)
        {
            repository.Delete(id);
        }

        public virtual List<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public virtual TEntity GetById(string id)
        {
            return repository.GetById(id);
        }

        public virtual void Update(TEntity entity)
        {
            repository.Update(entity);
        }
    }
}
