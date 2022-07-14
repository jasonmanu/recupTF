using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Purchase : Entity
    {
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        //public int CategoryId { get; set; }
        //public int BrandId { get; set; }
    }
}
