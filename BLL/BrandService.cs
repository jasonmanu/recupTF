using BLL.Contracts;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BrandService : BaseService<Brand>, IBrandService
    {
        public BrandService(IBaseRepository<Brand> repository) : base(repository)
        {
        }

        public override void Create(Brand entity)
        {
            if (!string.IsNullOrEmpty(entity.Name))
            {
                base.Create(entity);
            }
        }

        public string GetNameById(int id)
        {
            return base.GetById(id).Name;
        }
    }
}
