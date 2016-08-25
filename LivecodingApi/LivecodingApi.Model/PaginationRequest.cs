using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public class PaginationRequest
    {
        public string Search { get; set; }
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 100;
    }
}
