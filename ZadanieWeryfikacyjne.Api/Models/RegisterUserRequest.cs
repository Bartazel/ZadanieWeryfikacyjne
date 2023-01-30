using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ZadanieWeryfikacyjne.Models
{
    [SwaggerSchema]
    public class RegisterUserRequest
    {
        public RegisterUserRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required]
        [SwaggerSchema(Description = "Username of user to be registered", Format = "email")]
        public string Username { get; }

        [Required]
        [SwaggerSchema("Password of user to be registered")]
        public string Password { get; }
    }
}
