using Entities;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class BrandRepository : XmlRepository, IBrandRepository
    {
        public void Create(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return GetContext().BrandsRoot.Brands;
        }

        public Brand GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
