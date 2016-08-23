using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class XmppAccount
    {
        [JsonProperty("user")]
        public string UserUrl { get; set; }

        [JsonProperty("jid")]
        public string Jid { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("is_staff")]
        public bool IsStaff { get; set; }
    }
}
