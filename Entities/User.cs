﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : Entity
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
