﻿using System.Text.Json.Serialization;

namespace CompanyManagement.Models
{
    public class AddressModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("addressTypeId")]
        public string AddressTypeId { get; set; }

        [JsonPropertyName("addressType")]
        public AddressTypeModel? AddressType { get; set; }

        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }

        [JsonPropertyName("client")]
        public ClientModel? Client { get; set; }
    }
}
