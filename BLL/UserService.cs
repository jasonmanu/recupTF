using BLL.Contracts;
using Entities;
using Entities.Exceptions;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService : IUserService
    {
        List<User> users = new List<User>()
        {
            //new User("admin","admin", UserRole.ADMIN),
            new User("admin","?iv??A???M???g??s?K??o*?H?", UserRole.ADMIN),
            new User("seller","seller", UserRole.SELLER),
            new User("shopper","shopper", UserRole.SHOPPER)
        };

        public void Create(User entity)
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
            // username pasa a minuscula
            username = username?.ToLower();

            // verifica que datos de login no sean nulos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            // encripta password para comparar con los datos almacenados
            password = CryptoHelper.Hash(password);

            // retorna usuario si es login valido o null si los datos de login son invalidos
            return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public void Register(string username, string password)
        {
            // verifica que datos de regristro no sean nulos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new NullLoginException();

            // username pasa a minuscula
            username = username.ToLower();

            // verifica que el nombre de usuario no este en uso actualmente
            if (users.Any(x => x.Username == username))
                throw new UsernameExistsException();

            if (username.Length < 6 || password.Length < 6)
                throw new InvalidLengthException();

            // encripta password antes de guardarla
            password = CryptoHelper.Hash(password);

            // si paso las verificaciones se guarda en almacenamiento
            users.Add(new User(username, password, UserRole.SHOPPER));
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
