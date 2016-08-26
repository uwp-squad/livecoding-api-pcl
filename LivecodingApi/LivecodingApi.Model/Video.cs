using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class Video
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("user")]
        public string UserUrl { get; set; }

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

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("creation_time")]
        public string CreationDate { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("viewers_overall")]
        public int ViewersOverall { get; set; }

        [JsonProperty("viewing_urls")]
        public List<string> ViewingUrls { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("embed_url")]
        public string EmbedUrl { get; set; }
    }
}
