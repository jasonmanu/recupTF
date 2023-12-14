using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Loan : Entity
    {
        [XmlElement("BookId")]
        public string BookId { get; set; }

        [XmlElement("UserId")]
        public string UserId { get; set; }

        [XmlElement("StartDate")]
        public DateTime StartDate { get; set; }

        [XmlElement("EndDate")]
        public DateTime? EndDate { get; set; }

        [XmlElement("ReturnDate")]
        public DateTime? ReturnDate { get; set; }
    }
}
