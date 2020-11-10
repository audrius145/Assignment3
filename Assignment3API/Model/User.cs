using System.Text.Json.Serialization;

namespace Assignment3API.Model
{
    public class User
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; } 
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}