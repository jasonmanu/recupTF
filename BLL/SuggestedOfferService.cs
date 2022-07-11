using BLL.Contracts;
using DAL;
using DAL.Contracts;
using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class SuggestedOfferService : BaseService<SuggestedOffer>, ISuggestedOfferService
    {
        //private readonly ISuggestedOfferRepository repository;
        //private List<SuggestedOffer> suggestedOffers;
        //public SuggestedOfferService(ISuggestedOfferRepository repository)
        //{
        //    this.repository = repository;
        //}

        //private List<SuggestedOffer> suggestedOffers = new List<SuggestedOffer>()
        //{
        //    new SuggestedOffer(){
        //        Discount = 20,
        //        Start = new DateTime(DateTime.Now.Year, 12, 18),
        //        End = new DateTime(DateTime.Now.Year, 12, 31),
        //        Name = "Descuento por fiestas",
        //        Reason = "Festividad",
        //        Type = DiscountTypeEnum.Percentage,
        //        Id = 1
        //    },
        //     new SuggestedOffer(){
        //        Discount = 20,
        //        Start = new DateTime(DateTime.Now.Year, 08, 14),
        //        End = new DateTime(DateTime.Now.Year, 08, 21),
        //        Name = "Dia del niño",
        //        Reason = "Festividad",
        //        Type = DiscountTypeEnum.Percentage,
        //        Id = 2
        //    },
        //     new SuggestedOffer(){
        //        Discount = 20,
        //        Start = new DateTime(DateTime.Now.Year, 08, 14),
        //        End = new DateTime(DateTime.Now.Year, 08, 21),
        //        Name = "Dia del niño",
        //        Reason = "Prod sin ventas en 1 mes",
        //        Type = DiscountTypeEnum.Percentage,
        //        Id = 2
        //    },
        //};

        public SuggestedOfferService(IBaseRepository<SuggestedOffer> repository) : base(repository)
        {
        }
    }
}
