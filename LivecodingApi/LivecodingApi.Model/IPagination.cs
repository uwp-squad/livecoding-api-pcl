using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public interface IPagination
    {
        int Page { get; set; }
        int ItemsPerPage { get; set; }
        string Search { get; set; }
        string Ordering { get; set; }
        bool DescendingOrdering { get; set; }
        Dictionary<string, string> Filters { get; set; }
    }
}
