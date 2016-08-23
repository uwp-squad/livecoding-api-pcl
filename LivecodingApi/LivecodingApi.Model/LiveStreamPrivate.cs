using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class LiveStreamPrivate : LiveStream
    {
        [JsonProperty("streaming_key")]
        public string StreamingKey { get; set; }

        [JsonProperty("streaming_url")]
        public string StreamingUrl { get; set; }
    }
}
