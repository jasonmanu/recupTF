using System.Xml.Serialization;

namespace Entities
{
    public class Category : Entity
    {
        [XmlElement("Name")]
        public string Name { get; set; }
    }
}
