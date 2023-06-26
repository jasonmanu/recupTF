using BLL.Contracts;
using DAL;
using Entities;
using Entities.Enums;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class OfferService : BaseService<Offer>, IOfferService
    {
        private readonly IOfferRepository repository;
        private readonly IProductService productService;

        public OfferService(IOfferRepository repository, IProductService productService) : base(repository)
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

            if (entity.ProductId != null && entity.Type == DiscountTypeEnum.Amount)
            {
                Product product = productService.GetById((int)entity.ProductId);

                if (entity.Discount > product.Price)
                    throw new Exception("El descuento no puede ser mayor al precio del producto");
            }

            repository.Create(entity);
        }

        public float CalculateFinalPriceForProduct(int productId)
        {
            float productPrice = productService.GetById(productId).Price;
            List<Offer> offersForProduct = GetOffersByProductId(productId);

            if (offersForProduct != null && offersForProduct.Count > 0)
            {
                foreach (var offer in offersForProduct)
                {
                    if (offer.Type == DiscountTypeEnum.Amount)
                    {
                        productPrice = productPrice - offer.Discount;
                    }
                    else
                    {
                        productPrice = (productPrice * offer.Discount) / 100;
                    }
                }
            }

            return productPrice;
        }

        public List<Offer> GetOffersByProductId(int productId)
        {
            Product product = productService.GetById(productId);
            int productCategoryId = product.CategoryId;
            int productBrandId = product.BrandId;
            List<Offer> offers = repository.GetAll().Where(x => x.BrandId == productBrandId || x.CategoryId == productCategoryId || x.ProductId == productId).ToList();

            if (offers != null && offers.Count > 0)
            {
                List<Offer> activeOffers = offers.Where(x => DateHelper.GetOfferStatusByCurrentDate(x.Start, x.End)).ToList();
                return activeOffers;
            }

            return null;
        }
    }
}
