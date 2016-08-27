using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class PaginationRequest : IPagination
    {
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 100;
        public string Search { get; set; }
        public string Ordering { get; set; }
        public bool DescendingOrdering { get; set; }
    }
}
