using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reservation : Entity
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? RetireDate { get; set; }
    }
}
