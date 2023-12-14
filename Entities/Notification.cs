using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Notification: Entity
    {
        [XmlElement("Message")]
        public string Message { get; set; }

        [XmlElement("UserId")]
        public string UserId { get; set; }

        [XmlElement("Date")]
        public DateTime Date { get; set; }
    }
}
