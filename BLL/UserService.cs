using DAL;
using Entities;
using Entities.Exceptions;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository repository;
        private readonly IRoleService roleService;
        private const int MIN_USERNAME_LENGTH = 5;

        public UserService(IUserRepository repository, IRoleService roleService) : base(repository)
        {
            this.repository = repository;
            this.roleService = roleService;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            User user = repository.GetByUsername(username);

            if (user != null && user.IsActive == true)
            {
                string decryptedPassword = CryptoHelper.Decrypt(user.Password);

                if (password == decryptedPassword)
                {
                    Role rol = roleService.GetAll().FirstOrDefault(x => x.Name == user.RoleName);
                    user.Permisos = roleService.GetAllPermissions(rol);
                    return user;
                }
            }

            return null;
        }

        public override void Create(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                throw new NullLoginException();
            }

            bool usernameAlreadyExists = repository.GetByUsername(user.Username) != null;
            if (usernameAlreadyExists)
            {
                throw new UsernameExistsException();
            }

            if (user.Username.Length < MIN_USERNAME_LENGTH || user.Username.Length < MIN_USERNAME_LENGTH)
            {
                throw new InvalidPassLengthException();
            }

            user.Id = Guid.NewGuid().ToString();
            user.Password = CryptoHelper.Encrypt(user.Password);
            user.IsActive = true;

            repository.Create(user);
        }

        public override void Update(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                throw new NullLoginException();
            }

            if (user.Username.Length < MIN_USERNAME_LENGTH || user.Username.Length < MIN_USERNAME_LENGTH)
            {
                throw new InvalidPassLengthException();
            }

            user.Password = CryptoHelper.Encrypt(user.Password);

            repository.Update(user);
        }

        public override List<User> GetAll()
        {
            return base.GetAll().Where(x => x.IsActive == true).ToList();
        }
    }
}

