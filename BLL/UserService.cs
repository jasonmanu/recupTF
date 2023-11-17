using BLL.Contracts;
using DAL;
using Entities;
using Entities.Exceptions;
using FormSupport;
using System;

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

            User user = repository.GetByUsername(username);

            if (user != null)
            {
                string decryptedPassword = CryptoHelper.Decrypt(user.Password);

                if (password == decryptedPassword)
                {
                    return user;
                }
            }

            return null;
        }

        public void Register(User user)
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
                throw new InvalidLengthException();
            }

            user.Id = Guid.NewGuid().ToString();
            user.Password = CryptoHelper.Encrypt(user.Password);

            repository.Create(user);
        }
    }
}

