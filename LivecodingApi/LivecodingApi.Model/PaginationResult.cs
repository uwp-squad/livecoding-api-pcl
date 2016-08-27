using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class PaginationResult<T> : IPagination
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string NextUrl { get; set; }

        [JsonProperty("previous")]
        public string PreviousUrl { get; set; }

        [JsonProperty("results")]
        public IEnumerable<T> Results { get; set; }

        public bool HasPreviousPage { get { return !string.IsNullOrWhiteSpace(PreviousUrl); } }

        public bool HasNextPage { get { return !string.IsNullOrWhiteSpace(NextUrl); } }

        public int TotalPages { get { return (Count + ItemsPerPage - 1) / ItemsPerPage; } }

        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public string Search { get; set; }
        public string Ordering { get; set; }
    }
}
