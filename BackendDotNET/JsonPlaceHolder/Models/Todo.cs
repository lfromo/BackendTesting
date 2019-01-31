using Newtonsoft.Json;

namespace JsonPlaceHolder.Models
{
    public class Todo
    {
        [JsonProperty("userId")]
        public int userThatMustDoIt { get; set; }

        [JsonProperty("id")]
        public int todoId { get; set; }

        [JsonProperty("title")]
        public string todoTitle { get; set; }

        [JsonProperty("completed")]
        public bool isCompleted { get; set; }

    }
}
