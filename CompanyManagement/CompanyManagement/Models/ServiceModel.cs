using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CompanyManagement.Models;

public class ServiceModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}