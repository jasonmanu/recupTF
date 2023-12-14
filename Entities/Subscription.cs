using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Subscription : Entity
    {
        [XmlElement("UserId")]
        public string UserId { get; set; }

        [XmlElement("SubscriptionTypeId")]
        public string SubscriptionTypeId { get; set; }

        [XmlElement("StartDate")]
        public DateTime StartDate { get; set; }

        [XmlElement("EndDate")]
        public DateTime? EndDate { get; set; }
    }
}
