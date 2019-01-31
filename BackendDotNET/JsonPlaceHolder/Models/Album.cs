using Newtonsoft.Json;
using System.Xml.Serialization;

namespace JsonPlaceHolder.Models
{
    public class Album
    {
        [JsonProperty("userId")]
        public int ownerId { get; set; }

        [JsonProperty("id")]
        public int albumId { get; set; }

        public string title { get; set; }

    }
}
