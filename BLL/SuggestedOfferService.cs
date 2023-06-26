using BLL.Contracts;
using DAL;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class SuggestedOfferService : BaseService<SuggestedOffer>, ISuggestedOfferService
    {
        private readonly ISuggestedOfferRepository repository;
        private readonly IOrderService orderService;

        public SuggestedOfferService(ISuggestedOfferRepository repository, IOrderService orderService) : base(repository)
        {
            this.repository = repository;
            this.orderService = orderService;
        }

        public override List<SuggestedOffer> GetAll()
        {
            var orders = orderService.GetAll();
            var currentOffers = base.GetAll();
            var offerForCategoryWithLowSales = orders.GroupBy(x => x.ProductId).Count();
            return base.GetAll();
        }
    }
}
