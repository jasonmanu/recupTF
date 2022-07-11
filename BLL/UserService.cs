using BLL.Contracts;
using DAL;
using Entities;
using Entities.Exceptions;
using FormSupport;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IBaseRepository<User> repository;

        public UserService(IBaseRepository<User> repository) : base(repository)
        {
            this.repository = repository;
        }

        public override void Create(User entity)
        {
            // verifica que datos de regristro no sean nulos
            if (string.IsNullOrEmpty(entity.Username) || string.IsNullOrEmpty(entity.Password))
                throw new NullLoginException();

            // username pasa a minuscula
            entity.Username = entity.Username.ToLower();

            var users = repository.GetAll();

            if (users == null)
                throw new System.Exception("Problema al leer datos");

            // verifica que el nombre de usuario no este en uso actualmente
            if (users.Any(x => x.Username == entity.Username))
                throw new UsernameExistsException();

            const int minLength = 5;
            if (entity.Username.Length < minLength || entity.Username.Length < minLength)
                throw new InvalidLengthException();

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
                return null;

            // encripta password para comparar con los datos almacenados
            password = CryptoHelper.Hash(password);

            // retorna usuario si es login valido o null si los datos de login son invalidos
            return repository.GetAll()?.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
