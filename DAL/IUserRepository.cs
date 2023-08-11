﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByUsername(string username);
        User Login(LoginDto loginDto);
    }
}
