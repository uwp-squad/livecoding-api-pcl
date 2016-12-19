using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class LiveStreamStats
    {
        [JsonProperty("views_live")]
        public int ViewsLive { get; set; }

        [JsonProperty("item_class")]
        public string ItemClass { get; set; }

        [JsonProperty("views_overall")]
        public long ViewsOverall { get; set; }
    }
}
