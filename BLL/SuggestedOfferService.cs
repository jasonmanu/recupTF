using BLL.Contracts;
using DAL;
using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class SuggestedOfferService : BaseService<SuggestedOffer>, ISuggestedOfferService
    {
        private readonly IOrderService purchaseService;

        public SuggestedOfferService(IBaseRepository<SuggestedOffer> repository, IOrderService purchaseService) : base(repository)
        {
            this.purchaseService = purchaseService;
        }

        public override List<SuggestedOffer> GetAll()
        {
            return base.GetAll();
        }
    }
}
