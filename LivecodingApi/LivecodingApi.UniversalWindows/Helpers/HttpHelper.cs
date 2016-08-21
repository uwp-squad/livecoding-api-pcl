using LivecodingApi.Exceptions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
#if __IOS__ || __ANDROID__ || NET45
using System.Net.Http;
using HttpContent = System.Net.Http.HttpContent;
#endif
#if NETFX_CORE
using Windows.Web.Http;
using HttpContent = Windows.Web.Http.IHttpContent;
#endif

namespace LivecodingApi.Helpers
{
    internal class ExceptionDetail
    {
        [JsonProperty("detail")]
        public string Detail { get; set; }
    }

    internal static class HttpHelper
    {
        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string url)
        {
            using (httpClient)
            {
                var response = await httpClient.GetAsync(new Uri(url));
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var exceptionResponse = JsonConvert.DeserializeObject<ExceptionDetail>(result);
                    throw new ApiException(exceptionResponse.Detail, response.StatusCode);
                }

                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}