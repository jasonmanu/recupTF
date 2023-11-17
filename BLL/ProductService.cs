using BLL.Contracts;
using DAL;
using Entities;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;

        public ProductService(IProductRepository repository, ICategoryService categoryService, IBrandService brandService) : base(repository)
        {
            this.categoryService = categoryService;
            this.brandService = brandService;
        }

        public override void Create(Product entity)
        {
            if (entity.Price <= 0)
            {
                throw new Exception("Precio invalido");
            }

            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new Exception("Nombre invalido");
            }

            if (string.IsNullOrEmpty(entity.Description))
            {
                throw new Exception("Descripcion invalida");
            }

            base.Create(entity);
        }

        public List<ProductDto> GetExtendedProducts()
        {
            List<Product> products = GetAll();
            List<ProductDto> productsDto = new List<ProductDto>();

            if (products?.Count > 0)
            {
                foreach (Product product in products)
                {
                    productsDto.Add(new ProductDto()
                    {
                        BrandId = product.BrandId,
                        CategoryId = product.CategoryId,
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        CategoryName = categoryService.GetById(product.CategoryId)?.Name,
                        BrandName = brandService.GetNameById(product.BrandId),
                        OriginalPrice = product.Price,
                    });
                }
            }

            return productsDto;
        }

        public override void Update(Product entity)
        {
            if (entity.Id == null)
            {
                throw new Exception("No hay producto para actualizar");
            }

            if (entity.Price <= 0)
            {
                throw new Exception("Precio invalido");
            }

            base.Update(entity);
        }
    }
}
