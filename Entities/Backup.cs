using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Backup: Entity
    {
        [XmlElement("Action")]
        public string Action { get; set; }

        [XmlElement("Date")]
        public DateTime Date { get; set; }

        [XmlElement("Timestamp")]
        public string Timestamp { get; set; }

        [XmlElement("UserId")]
        public string UserId { get; set; }

        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlElement("File")]
        public string File { get; set; }
    }
}
