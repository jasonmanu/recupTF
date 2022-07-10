﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Offer : Entity
    {
        public bool Active { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Discount { get; set; }
        public string Name { get; set; }
        public DiscountTypeEnum Type { get; set; }
        public bool Suggested { get; set; }
    }
}
