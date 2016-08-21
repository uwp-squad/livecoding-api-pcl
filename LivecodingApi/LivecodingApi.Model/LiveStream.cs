using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class LiveStream
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("user")]
        public string UserUrl { get; set; }

        [JsonProperty("user__slug")]
        public string UserSlug { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("coding_category")]
        public string CodingCategory { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("is_live")]
        public bool IsLive { get; set; }

        [JsonProperty("viewers_live")]
        public int ViewersLive { get; set; }

        [JsonProperty("viewing_urls")]
        public List<string> ViewingUrls { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }
    }
}
