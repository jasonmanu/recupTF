using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Book : Entity
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("ISBN")]
        public string ISBN { get; set; }

        [XmlElement("Stock")]
        public int Stock { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("CategoryId")]
        public string CategoryId { get; set; }

        [XmlElement("AuthorId")]
        public string AuthorId { get; set; }

        [XmlElement("CollectionId")]
        public string CollectionId { get; set; }

        //[XmlElement("EditorialId")]
        //public string EditorialId { get; set; }
    }
}
