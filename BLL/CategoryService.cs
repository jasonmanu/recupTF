using DAL;
using Entities;
using System;

namespace BLL
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override void Create(Category entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new Exception("No se puede crear categoria sin nombre");
            }

            base.Create(entity);
        }

        public string GetNameById(string id)
        {
            return repository.GetById(id)?.Name;
        }
    }
}
