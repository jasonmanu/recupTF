using BLL.Contracts;
using DAL;
using Entities;

namespace BLL
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IBaseRepository<Category> repository;

        public CategoryService(IBaseRepository<Category> repository) : base(repository)
        {
            this.repository = repository;
        }

        public string GetNameById(int id)
        {
            return repository.GetById(id).Name;
        }
    }
}
