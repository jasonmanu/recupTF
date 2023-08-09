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
        public List<User> GetAll()
        {
            return GetContext().UsersRoot.Users;
        }

        public void Create(User entity)
        {
            XElement newUser = new XElement("User",
                                new XElement("Id", entity.Id),
                                new XElement("Username", entity.Username),
                                new XElement("Password", entity.Password),
                                new XElement("Role", entity.Role));

            rootDocument.Descendants("Users").FirstOrDefault().Add(newUser);
            SaveChanges();
        }

        public User GetByUsername(string username)
        {
            User user = GetAll().FirstOrDefault(x => x.Username == username);
            return user;
        }

        public void Delete(string id)
        {
            try
            {
                rootDocument.Descendants("User").FirstOrDefault(user => user.Element("Id")?.Value == id).Remove();
                SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public User GetById(string id)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataContext));
            DataContext results = (DataContext)serializer.Deserialize(rootDocument.CreateReader());
            User user = results.UsersRoot.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public void Update(User entity)
        {
            XElement userToUpdate = rootDocument.Descendants("User")
                                    .FirstOrDefault(user => user.Element("Id")?.Value == entity.Id);

            if (userToUpdate != null)
            {
                userToUpdate.Element("Username")?.SetValue(entity.Username);
                userToUpdate.Element("Password")?.SetValue(entity.Password);
                userToUpdate.Element("Role")?.SetValue(entity.Role);
                SaveChanges();
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
    }
}
