using LivecodingApi.Exceptions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using HttpContent = Windows.Web.Http.IHttpContent;

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