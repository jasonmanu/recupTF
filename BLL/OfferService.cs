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
    public class OfferService : IOfferService
    {
        List<Offer> offers = new List<Offer>()
        {
            new Offer()
            {
                Active=true,
                Name=$"50 % hasta {DateTime.Now.AddDays(-21).ToShortDateString()}",
                Discount = 50,
                Type = DiscountTypeEnum.Percentage,
                Start = DateTime.Now.AddDays(-20),
                End = DateTime.Now.AddDays(20),
                Id = 1
            },
            new Offer()
            {
                Active=false,
                Name = "$10",
                Discount = 10,
                Type = DiscountTypeEnum.Amount,
                Start = DateTime.Now.AddDays(-10),
                End = DateTime.Now.AddDays(10),
                Id = 2,
            },
            new Offer()
            {
                Active=true,
                Name= "33% navidad",
                Discount = 33,
                Start = DateTime.Now.AddDays(10),
                End = DateTime.Now.AddDays(20),
                Type = DiscountTypeEnum.Percentage,
                Id = 3,
            },
            new Offer()
            {
                Active=true,
                Name= "33% navidad",
                Discount = 33,
                Start = DateTime.Now.AddDays(10),
                End = DateTime.Now.AddDays(20),
                Type = DiscountTypeEnum.Percentage,
                Id = 3,
            },
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
