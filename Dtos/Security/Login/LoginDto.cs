
namespace Dtos.Security.Login
{
    using System.Text.Json.Serialization;
    public class LoginDto
    {
        [JsonIgnore]
        public string Issuer { get; set; } = string.Empty;
        [JsonIgnore]
        public string Audience { get; set; } = string.Empty;
        [JsonIgnore]
        public string Key { get; set; } = string.Empty;
        public string User { get; set; }
        public string Password { get; set; }
    }
}
