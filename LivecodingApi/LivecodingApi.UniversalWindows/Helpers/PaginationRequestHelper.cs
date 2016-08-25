using LivecodingApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Helpers
{
    internal static class PaginationRequestHelper
    {
        public static string CreateHttpQueryParams(PaginationRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                return $"?search={request.Search}";
            }

            return "";
        }
    }
}
