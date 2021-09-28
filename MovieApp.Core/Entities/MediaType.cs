using System.Text.Json.Serialization;

namespace MovieApp.Core.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MediaType
    {
        Movie,
        TvShow
    }
}
