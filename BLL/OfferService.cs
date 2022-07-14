using BLL.Contracts;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class OfferService : BaseService<Offer>, IOfferService
    {
        private readonly IBaseRepository<Offer> repository;
        private readonly IProductService productService;

        public OfferService(IBaseRepository<Offer> repository, IProductService productService) : base(repository)
        {
            this.repository = repository;
            this.productService = productService;
        }

        public override void Create(Offer entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
                throw new Exception("Nombre de la oferta no puede ser nulo");

            if (entity.ProductId == null && entity.CategoryId == null && entity.BrandId == null)
                throw new Exception("Seleccione una opcion para aplicar oferta");

            entity.CreatedAt = DateTime.Now;

            repository.Create(entity);
        }

        public List<Offer> GetOffersByProductId(int id)
        {
            var offers = repository.GetAll();// get by prod id
            //var productCategory = 
            return offers;
        }
    }
}
