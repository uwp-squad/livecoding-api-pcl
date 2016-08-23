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
using System.Reactive.Threading.Tasks;

namespace LivecodingApi.Services
{
    public class ReactiveLivecodingApiService : IReactiveLivecodingApiService
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

        public ReactiveLivecodingApiService() { }

        public ReactiveLivecodingApiService(string token)
        {
            Token = token;
        }

        #endregion

        #region Coding Categories

        public IObservable<PaginationResult<CodingCategory>> GetCodingCategoriesAsync(string search = null)
        {
            string url = _baseApiAddress + "codingcategories/";

            if (!string.IsNullOrWhiteSpace(search))
            {
                url += $"?search={search}";
            }

            return HttpClient.GetAsync<PaginationResult<CodingCategory>>(url)
                .ToObservable();
        }

        public IObservable<CodingCategory> GetCodingCategoryByNameAsync(string name)
        {
            string url = _baseApiAddress + $"codingcategories/{name}/";
            return HttpClient.GetAsync<CodingCategory>(url)
                .ToObservable();
        }

        #endregion

        #region Livestreams

        public IObservable<PaginationResult<LiveStream>> GetLiveStreamsAsync(string search = null)
        {
            string url = _baseApiAddress + "livestreams/";

            if (!string.IsNullOrWhiteSpace(search))
            {
                url += $"?search={search}";
            }

            return HttpClient.GetAsync<PaginationResult<LiveStream>>(url)
                .ToObservable();
        }

        public IObservable<PaginationResult<LiveStream>> GetLiveStreamsOnAirAsync()
        {
            string url = _baseApiAddress + "livestreams/onair/";
            return HttpClient.GetAsync<PaginationResult<LiveStream>>(url)
                .ToObservable();
        }

        public IObservable<LiveStream> GetCurrentLivestreamOfUserAsync(string userSlug)
        {
            string url = _baseApiAddress + $"livestreams/{userSlug}/";
            return HttpClient.GetAsync<LiveStream>(url)
                .ToObservable();
        }

        #endregion

        #region Languages

        public IObservable<PaginationResult<SiteLanguage>> GetLanguagesAsync(string search = null)
        {
            string url = _baseApiAddress + "languages/";

            if (!string.IsNullOrWhiteSpace(search))
            {
                url += $"?search={search}";
            }

            return HttpClient.GetAsync<PaginationResult<SiteLanguage>>(url)
                .ToObservable();
        }

        public IObservable<SiteLanguage> GetLanguageByIsoCodeAsync(string iso)
        {
            string url = _baseApiAddress + $"languages/{iso}/";
            return HttpClient.GetAsync<SiteLanguage>(url)
                .ToObservable();
        }

        #endregion

        #region Scheduled Broadcast

        public IObservable<PaginationResult<ScheduledBroadcast>> GetScheduledBroadcastsAsync()
        {
            string url = _baseApiAddress + "scheduledbroadcast/";
            return HttpClient.GetAsync<PaginationResult<ScheduledBroadcast>>(url)
                .ToObservable();
        }

        public IObservable<ScheduledBroadcast> GetScheduledBroadcastByIdAsync(string id)
        {
            string url = _baseApiAddress + $"scheduledbroadcast/{id}/";
            return HttpClient.GetAsync<ScheduledBroadcast>(url)
                .ToObservable();
        }

        #endregion

        #region Videos

        public IObservable<PaginationResult<Video>> GetVideosAsync()
        {
            string url = _baseApiAddress + "videos/";
            return HttpClient.GetAsync<PaginationResult<Video>>(url)
                .ToObservable();
        }

        public IObservable<Video> GetVideoBySlugAsync(string videoSlug)
        {
            string url = _baseApiAddress + $"videos/{videoSlug}/";
            return HttpClient.GetAsync<Video>(url)
                .ToObservable();
        }

        #endregion

        #region User

        public IObservable<UserPrivate> GetCurrentUserAsync()
        {
            string url = _baseApiAddress + "user/";
            return HttpClient.GetAsync<UserPrivate>(url)
                .ToObservable();
        }

        #endregion
    }
}
