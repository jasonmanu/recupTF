using Entities.Enums;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Entities
{
    public class User : Entity
    {
        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole Role { get; set; }
    }
}
