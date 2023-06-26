using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entities
{
    [XmlRoot("root")]
    public class DataContext
    {
        public DataContext()
        {
            UserRoot = new UsersRoot();
        }

        [XmlElement("users")]
        public UsersRoot UserRoot { get; set; }

        //[XmlElement("products")]
        //public List<Product> Product { get; set; }

        //[XmlElement("offers")]
        //public List<Offer> Offers { get; set; }

        //[XmlElement("SuggestedOffers")]
        //public List<SuggestedOffer> SuggestedOffers { get; set; }

        //[XmlElement("Purchases")]
        //public List<Order> Purchases { get; set; }

        //[XmlElement("ShopperFavorites")]
        //public List<ShopperFavorite> ShopperFavorites { get; set; }

        //[XmlElement("Categories")]
        //public List<Category> Categories { get; set; }
    }

    public class UsersRoot
    {
        public UsersRoot() { }

        [XmlElement("User")]
        public List<User> Users { get; set; }
    }
}
