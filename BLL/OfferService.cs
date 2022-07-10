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
                Name=$"50 % hasta {DateTime.Now.AddDays(-21).ToShortDateString()}",
                Type = DiscountType.Percentage
            },
            new Offer()
            {
                Active=false,
                CreatedAt=DateTime.Now.AddDays(-1),
                Discount = 10,
                Id = 2,
                Name = "$10",
                Type = DiscountType.Amount
            },
            new Offer()
            {
                Active=true,
                CreatedAt=DateTime.Now.AddDays(4),
                Discount = 33,
                Name= "33% navidad",
                Id = 3,
                Type = DiscountType.Percentage
            }
        };

        public void Create(Offer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            offers = offers.Where(x => x.Id != id).ToList();
        }

        public List<Offer> GetAll()
        {
            return offers;
        }

        public Offer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Offer entity)
        {
            offers = offers.Where(x => x.Id == entity.Id).Select(o => { o.Discount = entity.Discount; o.Active = entity.Active; o.Name = entity.Name; return o; }).ToList();
            Console.WriteLine("updated");
        }
    }
}
