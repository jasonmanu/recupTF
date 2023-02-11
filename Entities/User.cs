using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entities
{
    [Serializable]
    //[Serializable, XmlRoot("users")]
    public class User : Entity
    {
        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public User()
        {
        }

        //[XmlAttribute("username")]
        [XmlElement("username")]
        public string Username { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("role")]
        public UserRole Role { get; set; }
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
