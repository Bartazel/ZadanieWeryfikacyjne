using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ZadanieWeryfikacyjne.Models
{
    [SwaggerSchema]
    public class LoginUserRequest
    {
        public LoginUserRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required]
        [SwaggerSchema(Description = "Username", Format = "email")]
        public string Username { get; }

        [Required]
        [SwaggerSchema("User password")]
        public string Password { get; }
    }
}
