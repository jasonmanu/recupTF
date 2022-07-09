using BLL.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OfferService : IOfferService
    {
        List<Offer> offers = new List<Offer>()
        {
            new Offer()
            {
                Active=true,
                CreatedAt=DateTime.Now.AddDays(-21),
                Discount = 50,
                Id = 1,
                Type = DiscountType.Percentage
            },
            new Offer()
            {
                Active=false,
                CreatedAt=DateTime.Now.AddDays(-1),
                Discount = 50,
                Id = 2,
                Type = DiscountType.Percentage
            },
            new Offer()
            {
                Active=true,
                CreatedAt=DateTime.Now.AddDays(4),
                Discount = 50,
                Id = 3,
                Type = DiscountType.Percentage
            }
        };

        public void Create(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Offer> GetAll()
        {
            return offers;
        }

        public Offer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
