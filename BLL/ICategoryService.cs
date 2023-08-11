﻿using Entities;

namespace BLL.Contracts
{
    public interface ICategoryService : IBaseService<Category>
    {
        string GetNameById(string id);
    }
}