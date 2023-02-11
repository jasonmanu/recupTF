using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entities
{

    [XmlRoot("users")]
    public class Context
    {
        public Context()
        {
            Users = new List<User>();
        }

        [XmlElement("user")]
        public List<User> Users { get; set; }
    }

    //public class Context
    //{
    //    public List<User> Users { get; set; }
    //    public List<Offer> Offers { get; set; }
    //    public List<SuggestedOffer> SuggestedOffers { get; set; }
    //    public List<Product> Product { get; set; }
    //    public List<Order> Purchases { get; set; }
    //    public List<ShopperFavorite> ShopperFavorites { get; set; }
    //    //public List<Category> Categories { get; set; }
    //}
}
