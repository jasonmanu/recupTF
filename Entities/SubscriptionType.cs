using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class SubscriptionType : Entity
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public int Price { get; set; }

        [XmlElement("LoanDays")]
        public int LoanDays { get; set; }

        [XmlElement("MaxLoanBooks")]
        public int MaxLoanBooks { get; set; }
    }
}
