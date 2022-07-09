﻿using BLL.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService : IUserService
    {
        // load from XML
        List<User> users = new List<User>()
        {
            new User("admin","admin", UserRole.ADMIN),
            new User("seller","seller", UserRole.SELLER),
            new User("shopper","shopper", UserRole.SHOPPER)
        };

        public void Create(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public User Login(string username, string password)
        {
            username = username.ToLower();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public bool Register(string username, string password)
        {
            username = username.ToLower();

            if (users.Any(x => x.Username == username))
                return false;

            users.Add(new User(username, password, UserRole.SHOPPER));
            return true;
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
