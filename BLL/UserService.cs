using BLL.Contracts;
using DAL;
using Entities;
using Entities.Exceptions;
using FormSupport;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BLL
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly XElement rootDoc;
        private readonly string currentDirectory = Directory.GetCurrentDirectory();
        private string currentEntityName = typeof(User).Name.ToLower();
        private string fileName = "context.xml";

        private readonly IBaseRepository<User> repository;

        public UserService(IBaseRepository<User> repository) : base(repository)
        {
            string filePath = Path.Combine(currentDirectory, fileName);

            if (!File.Exists(filePath))
            {
                XDocument doc = new XDocument(new XElement("users"));
                // TODO: crear seed data con los datos de abajo, crear un seed para cada entity a guardar?
                //XDocument doc = new XDocument(new XElement("users",
                //                                    new XElement("user",
                //                                    new XElement("username", "admin"),
                //                                    new XElement("password", "admin"),
                //                                    new XElement("role", "ADMIN")),
                //                                    new XElement("user",
                //                                    new XElement("username", "shopper"),
                //                                    new XElement("password", "shopper"),
                //                                    new XElement("role", "SHOPPER")),
                //                                    new XElement("user",
                //                                    new XElement("username", "seller"),
                //                                    new XElement("password", "seller"),
                //                                    new XElement("role", "SELLER"))));
                doc.Save(filePath);
            }

            rootDoc = XElement.Load(filePath);

            this.repository = repository;
        }

        public override void Create(User entity)
        {
            // verifica que datos de regristro no sean nulos
            if (string.IsNullOrEmpty(entity.Username) || string.IsNullOrEmpty(entity.Password))
            {
                throw new NullLoginException();
            }

            // username pasa a minuscula
            entity.Username = entity.Username.ToLower();

            var users = repository.GetAll();

            if (users == null)
            {
                //crear archivo XML
                XmlDocument xmlDocument = new XmlDocument();
                //xmlDocument.Load();
                //throw new System.Exception("Problema al leer datos");
            }

            // verifica que el nombre de usuario no este en uso actualmente
            if (users.Any(x => x.Username == entity.Username))
            {
                throw new UsernameExistsException();
            }

            const int minLength = 5;
            if (entity.Username.Length < minLength || entity.Username.Length < minLength)
            {
                throw new InvalidLengthException();
            }

            // encripta password antes de guardarla
            entity.Password = CryptoHelper.Hash(entity.Password);

            // si paso las verificaciones se guarda en almacenamiento
            repository.Create(entity);
        }

        public User Login(string username, string password)
        {
            // username pasa a minuscula
            username = username?.ToLower();

            // verifica que datos de login no sean nulos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            // encripta password para comparar con los datos almacenados
            password = CryptoHelper.Hash(password);

            //XmlSerializer serializer = new XmlSerializer(typeof(UserRootXml), new XmlRootAttribute() { ElementName = "users", IsNullable = true });
            XmlSerializer serializer = new XmlSerializer(typeof(UserRootXml));
            UserRootXml results = (UserRootXml)serializer.Deserialize(rootDoc.CreateReader());

            // retorna usuario si es login valido o null si los datos de login son invalidos
            return results.Users?.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}

