using BLL.Contracts;
using DAL;
using Entities;

namespace BLL
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public string GetNameById(int id)
        {
            return repository.GetById(id).Name;
        }
    }
}
