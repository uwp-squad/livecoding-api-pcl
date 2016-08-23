using LivecodingApi.Configuration;
using LivecodingApi.Model;
using LivecodingApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if __IOS__ || __ANDROID__ || NET45
using System.Net.Http;
using System.Net.Http.Headers;
#endif
#if NETFX_CORE
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding;
#endif

namespace LivecodingApi.Services
{
    public class LivecodingApiService : ILivecodingApiService
    {
        #region Fields

        private readonly string _baseApiAddress = $"{Constants.ApiBaseUrl}{Constants.ApiVersion}";

        private HttpClient HttpClient
        {
            get
            {
                var httpClient = new HttpClient();

#if __IOS__ || __ANDROID__ || NET45
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(Token))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
#endif
#if NETFX_CORE
                httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(Token))
                    httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", Token);
#endif

                return httpClient;
            }
        }

        #endregion

        #region Properties

        public string Token { get; set; }

        #endregion

        #region Constructors

        public LivecodingApiService() { }

        public LivecodingApiService(string token)
        {
            Token = token;
        }

        #endregion

        #region Coding Categories

        public async Task<PaginationResult<CodingCategory>> GetCodingCategoriesAsync(string search = null)
        {
            string url = _baseApiAddress + "codingcategories/";

            if (!string.IsNullOrWhiteSpace(search))
            {
                url += $"?search={search}";
            }

            return await HttpClient.GetAsync<PaginationResult<CodingCategory>>(url);
        }

        public async Task<CodingCategory> GetCodingCategoryByNameAsync(string name)
        {
            string url = _baseApiAddress + $"codingcategories/{name}/";
            return await HttpClient.GetAsync<CodingCategory>(url);
        }

        #endregion

        #region Livestreams

        public async Task<PaginationResult<LiveStream>> GetLiveStreamsAsync(string search = null)
        {
            string url = _baseApiAddress + "livestreams/";

            if (!string.IsNullOrWhiteSpace(search))
            {
                url += $"?search={search}";
            }

            return await HttpClient.GetAsync<PaginationResult<LiveStream>>(url);
        }

        public async Task<PaginationResult<LiveStream>> GetLiveStreamsOnAirAsync()
        {
            string url = _baseApiAddress + "livestreams/onair/";
            return await HttpClient.GetAsync<PaginationResult<LiveStream>>(url);
        }

        public async Task<LiveStream> GetCurrentLivestreamOfUserAsync(string userSlug)
        {
            string url = _baseApiAddress + $"livestreams/{userSlug}/";
            return await HttpClient.GetAsync<LiveStream>(url);
        }

        #endregion

        #region Languages

        public async Task<PaginationResult<SiteLanguage>> GetLanguagesAsync(string search = null)
        {
            string url = _baseApiAddress + "languages/";

            if (!string.IsNullOrWhiteSpace(search))
            {
                url += $"?search={search}";
            }

            return await HttpClient.GetAsync<PaginationResult<SiteLanguage>>(url);
        }

        public async Task<SiteLanguage> GetLanguageByIsoCodeAsync(string iso)
        {
            string url = _baseApiAddress + $"languages/{iso}/";
            return await HttpClient.GetAsync<SiteLanguage>(url);
        }

        #endregion

        #region Scheduled Broadcast

        public async Task<PaginationResult<ScheduledBroadcast>> GetScheduledBroadcastsAsync()
        {
            string url = _baseApiAddress + "scheduledbroadcast/";
            return await HttpClient.GetAsync<PaginationResult<ScheduledBroadcast>>(url);
        }

        public async Task<ScheduledBroadcast> GetScheduledBroadcastByIdAsync(string id)
        {
            string url = _baseApiAddress + $"scheduledbroadcast/{id}/";
            return await HttpClient.GetAsync<ScheduledBroadcast>(url);
        }

        #endregion

        #region Videos

        public async Task<PaginationResult<Video>> GetVideosAsync()
        {
            string url = _baseApiAddress + "videos/";
            return await HttpClient.GetAsync<PaginationResult<Video>>(url);
        }

        public async Task<Video> GetVideoBySlugAsync(string videoSlug)
        {
            string url = _baseApiAddress + $"videos/{videoSlug}/";
            return await HttpClient.GetAsync<Video>(url);
        }

        #endregion

        #region User

        public async Task<UserPrivate> GetCurrentUserAsync()
        {
            string url = _baseApiAddress + "user/";
            return await HttpClient.GetAsync<UserPrivate>(url);
        }

        #endregion
    }
}
