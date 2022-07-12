using BLL.Contracts;
using DAL;
using Entities;

namespace BLL
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IBaseRepository<Category> repository) : base(repository)
        {
        }
    }
}
