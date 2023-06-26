using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entities
{
    [XmlRoot("root")]
    public class DataContext
    {
        public DataContext()
        {
            UsersRoot = new UsersRoot();
        }

        [XmlElement("Users")]
        public UsersRoot UsersRoot { get; set; }

        [XmlElement("Products")]
        public ProductsRoot ProductsRoot { get; set; }

        [XmlElement("Brands")]
        public BrandsRoot BrandsRoot { get; set; }

        [XmlElement("Offers")]
        public OffersRoot OffersRoot { get; set; }

        [XmlElement("SuggestedOffers")]
        public SuggestedOffersRoot SuggestedOffersRoot { get; set; }

        [XmlElement("Purchases")]
        public PurchasesRoot PurchasesRoot { get; set; }

        [XmlElement("ShopperFavorites")]
        public ShopperFavoritesRoot ShopperFavoritesRoot { get; set; }

        [XmlElement("Categories")]
        public CategoriesRoot CategoriesRoot { get; set; }
    }

    public class BrandsRoot
    {
        [XmlElement("Brand")]
        public List<Brand> Brands { get; set; }
    }

    public class CategoriesRoot
    {
        public CategoriesRoot()
        {
        }

        [XmlElement("Category")]
        public List<Category> Categories { get; set; }
    }

    public class ShopperFavoritesRoot
    {
        public ShopperFavoritesRoot()
        {
        }

        [XmlElement("ShopperFavorite")]
        public List<ShopperFavorite> ShopperFavorites { get; set; }
    }

    public class PurchasesRoot
    {
        public PurchasesRoot()
        {
        }

        [XmlElement("Purchase")]
        public List<Order> Purchases { get; set; }
    }

    public class UsersRoot
    {
        public UsersRoot()
        {
        }

        [XmlElement("User")]
        public List<User> Users { get; set; }
    }

    public class OffersRoot
    {
        public OffersRoot()
        {
        }

        [XmlElement("Offer")]
        public List<Offer> Offers { get; set; }
    }

    public class ProductsRoot
    {
        public ProductsRoot()
        {
        }

        [XmlElement("Product")]
        public List<Product> Products { get; set; }
    }

    public class SuggestedOffersRoot
    {
        public SuggestedOffersRoot()
        {
        }

        [XmlElement("SuggestedOffer")]
        public List<SuggestedOffer> SuggestedOffers { get; set; }
    }
}
