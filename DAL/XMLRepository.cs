using System.IO;
using System.Xml.Linq;

namespace DAL
{
    public class XmlRepository
    {
        protected XElement rootDocument;
        protected string filePath;
        private const string fileName = "data.xml";

        public XmlRepository()
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (!File.Exists(filePath))
            {
                XDocument doc = new XDocument(new XElement("root",
                                                new XElement("users"),
                                                new XElement("brands"),
                                                new XElement("products"),
                                                new XElement("categories")));
                doc.Save(filePath);
            }

            rootDocument = XElement.Load(filePath);
        }

        protected void SaveChanges()
        {
            rootDocument.Save(filePath);
        }
    }
}
