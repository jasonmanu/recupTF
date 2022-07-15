using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Context
    {
        public List<User> Users { get; set; }
        //public List<Category> Categories { get; set; }
        public List<Offer> Offers { get; set; }
        public List<SuggestedOffer> SuggestedOffers { get; set; }
        public List<Product> Product { get; set; }
        public List<Order> Purchases { get; set; }
        public List<ShopperFavorite> ShopperFavorites { get; set; }
    }
}
