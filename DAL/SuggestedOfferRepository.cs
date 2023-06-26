using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class SuggestedOfferRepository : XmlRepository, ISuggestedOfferRepository
    {
        public void Create(SuggestedOffer entity)
        {
            XElement suggestedOffer = new XElement("User",
                               new XElement("Discount", entity.Discount),
                               new XElement("Start", entity.Start),
                               new XElement("End", entity.End),
                               new XElement("Name", entity.Name));

            rootDocument.Descendants("SuggestedOffers").FirstOrDefault().Add(suggestedOffer);
            SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SuggestedOffer> GetAll()
        {
            return GetContext().SuggestedOffersRoot.SuggestedOffers;
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
