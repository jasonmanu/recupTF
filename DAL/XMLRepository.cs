using Entities;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    public class XmlRepository
    {
        protected XElement rootDocument;
        private string filePath;
        private const string fileName = "data.xml";

        public XmlRepository()
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (!File.Exists(filePath))
            {
                XDocument doc = new XDocument(new XElement("root",
                                                new XElement("Users"),
                                                new XElement("Brands"),
                                                new XElement("Products"),
                                                new XElement("Categories"),
                                                new XElement("Offers"),
                                                new XElement("SuggestedOffers"),
                                                new XElement("ShopperFavorites"),
                                                new XElement("Purchases"),
                                                new XElement("Categories")));
                doc.Save(filePath);
            }

            rootDocument = XElement.Load(filePath);
        }

        protected DataContext GetContext()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataContext));
            DataContext context = (DataContext)serializer.Deserialize(rootDocument.CreateReader());
            return context;
        }

        protected void SaveChanges()
        {
            rootDocument.Save(filePath);
        }
    }
}
