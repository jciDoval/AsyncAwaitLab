using System.Text.Json.Serialization;

namespace AsyncAwaitLab.Models.Jokes
{
    public class Joke
    {
        public bool Error { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = "";
        [JsonPropertyName("type")]
        public string Type { get; set; } = "";
        public string Setup { get; set; } = "";
        public string Delivery { get; set; } = "";
        public Flags Flags { get; set; } = new Flags();
        public int Id {get;set;}
        public bool Safe {get;set;} 
        public string Lang {get;set;} = "";

    }
}