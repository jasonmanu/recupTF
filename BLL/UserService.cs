using BLL.Contracts;
using DAL;
using Entities;
using Entities.Exceptions;
using FormSupport;
using System;
using System.Linq;

namespace BLL
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository repository;
        private const int MIN_USERNAME_LENGTH = 5;

        public UserService(IUserRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            password = CryptoHelper.Hash(password);

            // retorna usuario si es login valido o null si los datos de login son invalidos
            User user = repository.GetAll()?.FirstOrDefault(x => x.Username == username && x.Password == password);
            return user;
        }

        public void Register(User user)
        {
            // verifica que datos de registro no sean nulos
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                throw new NullLoginException();
            }

            // verifica que el nombre de usuario no este en uso actualmente
            bool usernameAlreadyExists = repository.GetByUsername(user.Username) != null;
            if (usernameAlreadyExists)
            {
                throw new UsernameExistsException();
            }

            // valida el tamaño minimo del username
            if (user.Username.Length < MIN_USERNAME_LENGTH || user.Username.Length < MIN_USERNAME_LENGTH)
            {
                throw new InvalidLengthException();
            }

            user.Id = Guid.NewGuid().ToString();

            // encripta password antes de guardarla
            user.Password = CryptoHelper.Hash(user.Password);

            repository.Create(user);
        }
    }
}

