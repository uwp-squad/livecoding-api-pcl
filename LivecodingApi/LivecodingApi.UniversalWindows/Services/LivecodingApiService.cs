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

namespace LivecodingApi.Services
{
    public interface ILivecodingApiService
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
        /// <returns></returns>
        Task<PaginationResult<CodingCategory>> GetCodingCategoriesAsync();

        /// <summary>
        /// Returns a coding category based on his name
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Coding_Categories_retrieve)
        /// </summary>
        /// <param name="name">Name of the category</param>
        /// <returns></returns>
        Task<CodingCategory> GetCodingCategoryByNameAsync(string name);

        #endregion

        #region Livestreams

        /// <summary>
        /// Returns all livestreams
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Live_Stream_list)
        /// </summary>
        /// <returns></returns>
        Task<PaginationResult<LiveStream>> GetLiveStreamsAsync();

        /// <summary>
        /// Returns all livestreams currently on air
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Live_Stream_onair)
        /// </summary>
        /// <returns></returns>
        Task<PaginationResult<LiveStream>> GetLiveStreamsOnAirAsync();

        /// <summary>
        /// Returns livestream of a user
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Live_Stream_retrieve)
        /// </summary>
        /// <param name="userSlug">Username slug</param>
        /// <returns></returns>
        Task<LiveStream> GetCurrentLivestreamOfUser(string userSlug);

        #endregion

        #region Languages

        /// <summary>
        /// Returns all languages used in the site (human languages)
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Site_Languages_list)
        /// </summary>
        /// <returns></returns>
        Task<PaginationResult<SiteLanguage>> GetLanguagesAsync();

        /// <summary>
        /// Returns a language by its ISO code
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Site_Languages_retrieve)
        /// </summary>
        /// <param name="iso">Iso code (ex: "fr")</param>
        /// <returns></returns>
        Task<SiteLanguage> GetLanguageByIsoCodeAsync(string iso);

        #endregion
    }

    public class LivecodingApiService : ILivecodingApiService
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

        public LivecodingApiService() { }

        public LivecodingApiService(string token)
        {
            Token = token;
        }

        #endregion

        #region Coding Categories

        public async Task<PaginationResult<CodingCategory>> GetCodingCategoriesAsync()
        {
            string url = _baseApiAddress + "codingcategories";
            return await HttpClient.GetAsync<PaginationResult<CodingCategory>>(url);
        }

        public async Task<CodingCategory> GetCodingCategoryByNameAsync(string name)
        {
            string url = _baseApiAddress + $"codingcategories/{name}";
            return await HttpClient.GetAsync<CodingCategory>(url);
        }

        #endregion

        #region Livestreams

        public async Task<PaginationResult<LiveStream>> GetLiveStreamsAsync()
        {
            string url = _baseApiAddress + "livestreams";
            return await HttpClient.GetAsync<PaginationResult<LiveStream>>(url);
        }

        public async Task<PaginationResult<LiveStream>> GetLiveStreamsOnAirAsync()
        {
            string url = _baseApiAddress + "livestreams/onair";
            return await HttpClient.GetAsync<PaginationResult<LiveStream>>(url);
        }

        public async Task<LiveStream> GetCurrentLivestreamOfUser(string userSlug)
        {
            string url = _baseApiAddress + $"livestreams/{userSlug}";
            return await HttpClient.GetAsync<LiveStream>(url);
        }

        #endregion

        #region Languages

        public async Task<PaginationResult<SiteLanguage>> GetLanguagesAsync()
        {
            string url = _baseApiAddress + "languages";
            return await HttpClient.GetAsync<PaginationResult<SiteLanguage>>(url);
        }

        public async Task<SiteLanguage> GetLanguageByIsoCodeAsync(string iso)
        {
            string url = _baseApiAddress + $"languages/{iso}";
            return await HttpClient.GetAsync<SiteLanguage>(url);
        }

        #endregion
    }
}
