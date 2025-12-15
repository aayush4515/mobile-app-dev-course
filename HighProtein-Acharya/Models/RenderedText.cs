using System.Text.Json.Serialization;

namespace HighProtein_Acharya.Models
{
    public class RenderedText
    {
        [JsonPropertyName("rendered")]
        public string? Rendered { get; set; }
    }
}