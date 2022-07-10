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
            }
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
