using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class User
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("favorite_programming")]
        public string FavoriteProgamming { get; set; }

        [JsonProperty("favorite_ide")]
        public string FavoriteIde { get; set; }

        [JsonProperty("favorite_coding_background_music")]
        public string FavoriteCodingBackgroundMusic { get; set; }

        [JsonProperty("favorite_code")]
        public string FavoriteCode { get; set; }

        [JsonProperty("years_programming")]
        public int YearsProgramming { get; set; }

        [JsonProperty("want_learn")]
        public List<string> WantLearn { get; set; }

        [JsonProperty("registration_date")]
        public string RegistrationDate { get; set; }
    }
}
