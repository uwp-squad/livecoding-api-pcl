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
using Windows.Security.Authentication.Web;
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

        #region Authentication

        public async Task<bool?> LoginAsync(string oauthKey, string oauthSecret, string[] scopes)
        {
#if NETFX_CORE
            // Check scopes variable
            if (scopes.All(s => s != AuthenticationScope.Read))
            {
                throw new Exception($"The authentication scope '{AuthenticationScope.Read}' is required.");
            }

            var notScopes = scopes.Where(s => !AuthenticationScope.All.Contains(s));
            if (notScopes.Any())
            {
                string notScopesJoined = string.Join(", ", notScopes);
                throw new Exception($"The following authentication scopes does not exist : {notScopesJoined}.");
            }

            // Create Auth url
            var state = Guid.NewGuid();
            string scopesJoined = string.Join(" ", scopes);

            string startUrl = $"https://www.livecoding.tv/o/authorize?scope={scopesJoined}&state={state}&redirect_uri={AuthHelper.RedirectUrl}&response_type=token&client_id={oauthKey}";
            var startUri = new Uri(startUrl);
            var endUri = new Uri(AuthHelper.RedirectUrl);

            try
            {
                // Launch authentication webview
                var webAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startUri, endUri);
                Token = AuthHelper.RetrieveToken(webAuthenticationResult, oauthKey, oauthSecret);
                return !string.IsNullOrWhiteSpace(Token);
            }
            catch
            {
                return null;
            }
#else
            throw new NotImplementedException();
#endif
        }

        #endregion

        #region Coding Categories

        public async Task<PaginationResult<CodingCategory>> GetCodingCategoriesAsync(PaginationRequest request)
        {
            string url = _baseApiAddress + "codingcategories/";
            url += PaginationHelper.CreateHttpQueryParams(request);
            return await HttpClient.GetAsync<PaginationResult<CodingCategory>>(url)
                .PaginationContinuation(request);
        }

        public async Task<CodingCategory> GetCodingCategoryByNameAsync(string name)
        {
            string url = _baseApiAddress + $"codingcategories/{name}/";
            return await HttpClient.GetAsync<CodingCategory>(url);
        }

        #endregion

        #region Livestreams

        public async Task<PaginationResult<LiveStream>> GetLiveStreamsAsync(PaginationRequest request)
        {
            string url = _baseApiAddress + "livestreams/";
            url += PaginationHelper.CreateHttpQueryParams(request);
            return await HttpClient.GetAsync<PaginationResult<LiveStream>>(url)
                .PaginationContinuation(request);
        }

        public async Task<PaginationResult<LiveStream>> GetLiveStreamsOnAirAsync(PaginationRequest request)
        {
            string url = _baseApiAddress + "livestreams/onair/";
            url += PaginationHelper.CreateHttpQueryParams(request);
            return await HttpClient.GetAsync<PaginationResult<LiveStream>>(url)
                .PaginationContinuation(request);
        }

        public async Task<LiveStream> GetCurrentLivestreamOfUserAsync(string userSlug)
        {
            string url = _baseApiAddress + $"livestreams/{userSlug}/";
            return await HttpClient.GetAsync<LiveStream>(url);
        }

        #endregion

        #region Languages

        public async Task<PaginationResult<SiteLanguage>> GetLanguagesAsync(PaginationRequest request)
        {
            string url = _baseApiAddress + "languages/";
            url += PaginationHelper.CreateHttpQueryParams(request);
            return await HttpClient.GetAsync<PaginationResult<SiteLanguage>>(url)
                .PaginationContinuation(request);
        }

        public async Task<SiteLanguage> GetLanguageByIsoCodeAsync(string iso)
        {
            string url = _baseApiAddress + $"languages/{iso}/";
            return await HttpClient.GetAsync<SiteLanguage>(url);
        }

        #endregion

        #region Scheduled Broadcast

        public async Task<PaginationResult<ScheduledBroadcast>> GetScheduledBroadcastsAsync(PaginationRequest request)
        {
            string url = _baseApiAddress + "scheduledbroadcast/";
            url += PaginationHelper.CreateHttpQueryParams(request);
            return await HttpClient.GetAsync<PaginationResult<ScheduledBroadcast>>(url)
                .PaginationContinuation(request);
        }

        public async Task<ScheduledBroadcast> GetScheduledBroadcastByIdAsync(string id)
        {
            string url = _baseApiAddress + $"scheduledbroadcast/{id}/";
            return await HttpClient.GetAsync<ScheduledBroadcast>(url);
        }

        #endregion

        #region Videos

        public async Task<PaginationResult<Video>> GetVideosAsync(PaginationRequest request)
        {
            string url = _baseApiAddress + "videos/";
            url += PaginationHelper.CreateHttpQueryParams(request);
            return await HttpClient.GetAsync<PaginationResult<Video>>(url)
                .PaginationContinuation(request);
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

        public async Task<IEnumerable<User>> GetFollowersAsync()
        {
            string url = _baseApiAddress + "user/followers/";
            return await HttpClient.GetAsync<IEnumerable<User>>(url);
        }

        public async Task<IEnumerable<User>> GetFollowsAsync()
        {
            string url = _baseApiAddress + "user/follows/";
            return await HttpClient.GetAsync<IEnumerable<User>>(url);
        }

        public async Task<XmppAccount> GetXmppAccountAsync()
        {
            string url = _baseApiAddress + "user/chat/account/";
            return await HttpClient.GetAsync<XmppAccount>(url);
        }

        public async Task<PaginationResult<LiveStreamPrivate>> GetUserLivestreamsAsync(PaginationRequest request)
        {
            string url = _baseApiAddress + "user/livestreams/";
            url += PaginationHelper.CreateHttpQueryParams(request);
            return await HttpClient.GetAsync<PaginationResult<LiveStreamPrivate>>(url)
                .PaginationContinuation(request);
        }

        public async Task<PaginationResult<LiveStreamPrivate>> GetUserLivestreamsOnAirAsync(PaginationRequest request)
        {
            string url = _baseApiAddress + "user/livestreams/onair/";
            url += PaginationHelper.CreateHttpQueryParams(request);
            return await HttpClient.GetAsync<PaginationResult<LiveStreamPrivate>>(url)
                .PaginationContinuation(request);
        }

        public async Task<PaginationResult<Video>> GetUserVideosAsync(PaginationRequest request)
        {
            string url = _baseApiAddress + "user/videos/";
            url += PaginationHelper.CreateHttpQueryParams(request);
            return await HttpClient.GetAsync<PaginationResult<Video>>(url)
                .PaginationContinuation(request);
        }

        public async Task<IEnumerable<Video>> GetUserLatestVideosAsync()
        {
            string url = _baseApiAddress + "user/videos/latest/";
            return await HttpClient.GetAsync<IEnumerable<Video>>(url);
        }

        #endregion
    }
}
