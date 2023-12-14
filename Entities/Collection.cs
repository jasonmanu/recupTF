using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Collection : Entity
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("AuthorId")]
        public string AuthorId { get; set; }

        [XmlElement("CategoryId")]
        public string CategoryId { get; set; }
    }
}
