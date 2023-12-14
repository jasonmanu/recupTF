using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Author : Entity
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
