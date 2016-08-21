using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class ScheduledBroadcast
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("livestream")]
        public string LivestreamUrl { get; set; }

        [JsonProperty("coding_category")]
        public string CodingCategory { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("start_time")]
        public string StartDate { get; set; }

        [JsonProperty("start_time_original_timezone")]
        public string StartDateOriginalTimezone { get; set; }

        [JsonProperty("original_timezone")]
        public string OriginalTimezone { get; set; }

        [JsonProperty("is_featured")]
        public bool IsFeatured { get; set; }

        [JsonProperty("is_recurring")]
        public bool IsRecurring { get; set; }
    }
}
