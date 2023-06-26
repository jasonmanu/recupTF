using BLL.Contracts;
using DAL;
using Entities;
using System;

namespace BLL
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository): base(repository)
        {
            this.repository = repository;
        }

        public override void Create(Product entity)
        {
            if(entity.Price <= 0)
            {
                throw new Exception("Precio invalido");
            }

            base.Create(entity);
        }

        public override void Update(Product entity)
        {
            if (entity.Price <= 0)
            {
                throw new Exception("Precio invalido");
            }

            base.Update(entity);
        }
    }
}
