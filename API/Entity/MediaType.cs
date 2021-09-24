using System.Text.Json.Serialization;

namespace API.Entity
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MediaType
    {
        Movie,
        TvShow
    }
}
