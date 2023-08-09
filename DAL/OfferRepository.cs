using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public class OfferRepository : XmlRepository, IOfferRepository
    {
        public void Create(Offer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Offer> GetAll()
        {
            return GetContext().OffersRoot.Offers;
        }

        public Offer GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Offer entity)
        {
            throw new NotImplementedException();
        }
    }
}
