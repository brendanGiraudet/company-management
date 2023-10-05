using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CompanyManagement.Models
{
    public class ClientModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        public required string PhoneNumber { get; set; }

        [JsonPropertyName("adresses")]
        public HashSet<AddressModel>? Addresses { get; set; }
    }
}
