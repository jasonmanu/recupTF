﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Purchase
    {
        public DateTime Date { get; set; }
        public List<Product> Products { get; set; }
        public int UserId { get; set; }
    }
}