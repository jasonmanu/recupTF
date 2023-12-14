using Entities;

namespace BLL
{
    public interface ICategoryService : IBaseService<Category>
    {
        string GetNameById(string id);
    }
}
