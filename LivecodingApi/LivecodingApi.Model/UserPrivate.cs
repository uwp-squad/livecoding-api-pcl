using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class UserPrivate : User
    {
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
