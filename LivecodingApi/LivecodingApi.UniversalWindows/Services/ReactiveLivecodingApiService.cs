using LivecodingApi.Configuration;
using LivecodingApi.Model;
using LivecodingApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding;
using System.Reactive.Threading.Tasks;

namespace LivecodingApi.UniversalWindows.Services
{
    public interface IReactiveLivecodingApiService
    {
        #region Properties

        /// <summary>
        /// Token used by the Livecoding API to provide access to the entire API
        /// </summary>
        string Token { get; set; }

        #endregion

        #region Coding Categories

        /// <summary>
        /// Returns all coding categories
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Coding_Categories_list)
        /// </summary>
        /// <param name="search">Search coding categories (based on fields 'name', 'slug' or 'sort')</param>
        /// <returns></returns>
        IObservable<PaginationResult<CodingCategory>> GetCodingCategoriesAsync(string search = null);

        /// <summary>
        /// Returns a coding category based on his name
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Coding_Categories_retrieve)
        /// </summary>
        /// <param name="name">Name of the category</param>
        /// <returns></returns>
        IObservable<CodingCategory> GetCodingCategoryByNameAsync(string name);

        #endregion

        #region Livestreams

        /// <summary>
        /// Returns all livestreams
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Live_Stream_list)
        /// </summary>
        /// <param name="search">Search livestreams (based on fields 'title', 'description' or 'tags')</param>
        /// <returns></returns>
        IObservable<PaginationResult<LiveStream>> GetLiveStreamsAsync(string search = null);

        /// <summary>
        /// Returns all livestreams currently on air
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Live_Stream_onair)
        /// </summary>
        /// <returns></returns>
        IObservable<PaginationResult<LiveStream>> GetLiveStreamsOnAirAsync();

        /// <summary>
        /// Returns livestream of a user
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Live_Stream_retrieve)
        /// </summary>
        /// <param name="userSlug">Username slug</param>
        /// <returns></returns>
        IObservable<LiveStream> GetCurrentLivestreamOfUserAsync(string userSlug);

        #endregion

        #region Languages

        /// <summary>
        /// Returns all languages used in the site (human languages)
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Site_Languages_list)
        /// </summary>
        /// <param name="search">Search languages (based on field 'name')</param>
        /// <returns></returns>
        IObservable<PaginationResult<SiteLanguage>> GetLanguagesAsync(string search = null);

        /// <summary>
        /// Returns a language by its ISO code
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Site_Languages_retrieve)
        /// </summary>
        /// <param name="iso">Iso code (ex: "fr")</param>
        /// <returns></returns>
        IObservable<SiteLanguage> GetLanguageByIsoCodeAsync(string iso);

        #endregion

        #region Scheduled Broadcast

        /// <summary>
        /// Returns all scheduled broadcasts
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Scheduled_Broadcast_list)
        /// </summary>
        /// <returns></returns>
        IObservable<PaginationResult<ScheduledBroadcast>> GetScheduledBroadcastsAsync();

        /// <summary>
        /// Returns a scheduled broadcast by its id
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Scheduled_Broadcast_retrieve)
        /// </summary>
        /// <param name="id">Id of the scheduled broadcast</param>
        /// <returns></returns>
        IObservable<ScheduledBroadcast> GetScheduledBroadcastByIdAsync(string id);

        #endregion

        #region Videos

        /// <summary>
        /// Returns all videos
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Video_list)
        /// </summary>
        /// <returns></returns>
        IObservable<PaginationResult<Video>> GetVideosAsync();

        /// <summary>
        /// Returns a video by its slug
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Video_retrieve)
        /// </summary>
        /// <param name="slug">Slug of the video</param>
        /// <returns></returns>
        IObservable<Video> GetVideoBySlugAsync(string videoSlug);

        #endregion

        #region User

        /// <summary>
        /// Returns current user info
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Account_User_list)
        /// </summary>
        /// <returns></returns>
        IObservable<User> GetCurrentUserAsync();

        #endregion
    }

    public class ReactiveLivecodingApiService : IReactiveLivecodingApiService
    {
        #region Fields

        private readonly string _baseApiAddress = $"{Constants.ApiBaseUrl}{Constants.ApiVersion}";

        private HttpClient HttpClient
        {
            get
            {
                var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(Token))
                    httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", Token);

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

        public IObservable<User> GetCurrentUserAsync()
        {
            string url = _baseApiAddress + "user/";
            return HttpClient.GetAsync<User>(url)
                .ToObservable();
        }

        #endregion
    }
}
