using DAL.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public class UserRepository// : IUserRepository
    {
        private List<User> users;

        public UserRepository(IBaseRepository<User> repository): base()
        {
            //try
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(List<User>), null, null, new XmlRootAttribute(xmlPath), "http://ofimbres.wordpress.com/");
            //    using (StreamReader myWriter = new StreamReader(xmlPath))
            //    {
            //        users = (List<User>)serializer.Deserialize(myWriter);
            //        myWriter.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}



//private readonly List<User> users;
//private readonly string xmlFilePath = $"{Directory.GetCurrentDirectory()}..\\..\\Backup\\Users.xml";
////private readonly string xmlFilePath;
////private string FileName { get; }

//public UserRepository()
//{
//    try
//    {
//        XmlSerializer serializer = new XmlSerializer(typeof(List<User>), null, null, new XmlRootAttribute("Users"), "http://ofimbres.wordpress.com/");
//        using (StreamReader myWriter = new StreamReader(xmlFilePath))
//        {
//            users = (List<User>)serializer.Deserialize(myWriter);
//            myWriter.Close();
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//    //XmlSerializer serializer = new XmlSerializer(typeof(List<User>), null, new Type[] { typeof(BinaryConfiguration) }, new XmlRootAttribute("Configurations"), "http://ofimbres.wordpress.com/");
//}


////public UserRepository()
////{
////    //string aux = Path.Combine();
////    xmlPath = $"{Directory.GetCurrentDirectory()}/backup/users.xml";

////    if (!Directory.Exists(xmlPath))
////    {
////        Directory.CreateDirectory(xmlPath);
////    }
////}

//public void Create(User entity)
//{
//    users.Add(entity);
//    SaveChanges();
//}

//public void Delete(int id)
//{
//    var entityToDelete = users.FirstOrDefault(x => x.Id == id);
//    users.Remove(entityToDelete);
//    SaveChanges();
//}

//public List<User> GetAll()
//{
//    return users;
//}

//public User GetById(int id)
//{
//    var entity = users.FirstOrDefault(x => x.Id == id);
//    return entity;
//}

//public void Update(User entity)
//{
//    throw new NotImplementedException();
//}

//public void SaveChanges()
//{
//    //XmlSerializer serializer = new XmlSerializer(users.GetType(), null, new Type[] { typeof(BinaryConfiguration) }, new XmlRootAttribute("Configurations"), "http://ofimbres.wordpress.com/");
//    XmlSerializer serializer = new XmlSerializer(users.GetType(), null, null, new XmlRootAttribute("Users"), "http://ofimbres.wordpress.com/");
//    using (StreamWriter myWriter = new StreamWriter(xmlFilePath))
//    {
//        serializer.Serialize(myWriter, users);
//        myWriter.Close();
//    }
//}