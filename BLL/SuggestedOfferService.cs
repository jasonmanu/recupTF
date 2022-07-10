using BLL.Contracts;
using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SuggestedOfferService : ISuggestedOfferService
    {
        private List<SuggestedOffer> suggestedOffers = new List<SuggestedOffer>()
        {
            new SuggestedOffer(){
                Discount = 20,
                Start = new DateTime(DateTime.Now.Year, 12, 18),
                End = new DateTime(DateTime.Now.Year, 12, 31),
                Name = "Descuento por fiestas",
                Reason = "Festividad",
                Type = DiscountTypeEnum.Percentage,
                Id = 1
            },
             new SuggestedOffer(){
                Discount = 20,
                Start = new DateTime(DateTime.Now.Year, 08, 14),
                End = new DateTime(DateTime.Now.Year, 08, 21),
                Name = "Dia del niño",
                Reason = "Festividad",
                Type = DiscountTypeEnum.Percentage,
                Id = 2
            },
             new SuggestedOffer(){
                Discount = 20,
                Start = new DateTime(DateTime.Now.Year, 08, 14),
                End = new DateTime(DateTime.Now.Year, 08, 21),
                Name = "Dia del niño",
                Reason = "Prod sin ventas en 1 mes",
                Type = DiscountTypeEnum.Percentage,
                Id = 2
            },
        };

        public void Create(SuggestedOffer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SuggestedOffer> GetAll()
        {
            //var purchases = 
            return suggestedOffers;
        }

        public SuggestedOffer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SuggestedOffer entity)
        {
            throw new NotImplementedException();
        }
    }
}
