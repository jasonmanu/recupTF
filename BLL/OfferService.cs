using BLL.Contracts;
using DAL;
using Entities;
using System;

namespace BLL
{
    public class OfferService : BaseService<Offer>, IOfferService
    {
        private readonly IBaseRepository<Offer> repository;

        public OfferService(IBaseRepository<Offer> repository) : base(repository)
        {
            this.repository = repository;
        }

        public override void Create(Offer entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
                throw new Exception("Nombre de la oferta no puede ser nulo");

            repository.Create(entity);
        }
    }
}
