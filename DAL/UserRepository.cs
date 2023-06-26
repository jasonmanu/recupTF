using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    public class UserRepository : XmlRepository, IUserRepository
    {
        public User GetByUsername(string username)
        {
            User user = GetAll().FirstOrDefault(x => x.Username == username);
            return user;
        }

        public List<User> GetAll()
        {
            return GetContext().UsersRoot.Users;
        }

        public void Create(User entity)
        {
            XElement newUser = new XElement("User",
                                new XElement("Username", entity.Username),
                                new XElement("Password", entity.Password),
                                new XElement("Role", entity.Role));

            rootDocument.Descendants("Users").FirstOrDefault().Add(newUser);
            SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataContext));
            DataContext results = (DataContext)serializer.Deserialize(rootDocument.CreateReader());
            User user = results.UsersRoot.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
