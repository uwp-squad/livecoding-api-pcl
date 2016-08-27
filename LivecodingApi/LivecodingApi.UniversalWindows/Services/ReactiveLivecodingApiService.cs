using LivecodingApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace LivecodingApi.Services
{
    public class ReactiveLivecodingApiService : IReactiveLivecodingApiService
    {
        #region Fields

        private ILivecodingApiService _apiService = new LivecodingApiService();

        #endregion

        #region Properties

        public string Token { get { return _apiService.Token; } }

        #endregion

        #region Constructors

        public ReactiveLivecodingApiService() { }

        public ReactiveLivecodingApiService(string token)
        {
            _apiService.Token = token;
        }

        #endregion

        #region Authentication

        public IObservable<bool?> Login(string oauthKey, string oauthSecret, string[] scopes)
        {
#if NETFX_CORE
            return _apiService.LoginAsync(oauthKey, oauthSecret, scopes).ToObservable();
#else
            throw new NotImplementedException();
#endif
        }

        #endregion

        #region Coding Categories

        public IObservable<PaginationResult<CodingCategory>> GetCodingCategories(PaginationRequest request)
        {
            return _apiService.GetCodingCategoriesAsync(request).ToObservable();
        }

        public IObservable<CodingCategory> GetCodingCategoryByName(string name)
        {
            return _apiService.GetCodingCategoryByNameAsync(name).ToObservable();
        }

        #endregion

        #region Livestreams

        public IObservable<PaginationResult<LiveStream>> GetLiveStreams(PaginationRequest request)
        {
            return _apiService.GetLiveStreamsAsync(request).ToObservable();
        }

        public IObservable<PaginationResult<LiveStream>> GetLiveStreamsOnAir(PaginationRequest request)
        {
            return _apiService.GetLiveStreamsOnAirAsync(request).ToObservable();
        }

        public IObservable<LiveStream> GetCurrentLivestreamOfUser(string userSlug)
        {
            return _apiService.GetCurrentLivestreamOfUserAsync(userSlug).ToObservable();
        }

        #endregion

        #region Languages

        public IObservable<PaginationResult<SiteLanguage>> GetLanguages(PaginationRequest request)
        {
            return _apiService.GetLanguagesAsync(request).ToObservable();
        }

        public IObservable<SiteLanguage> GetLanguageByIsoCode(string iso)
        {
            return _apiService.GetLanguageByIsoCodeAsync(iso).ToObservable();
        }

        #endregion

        #region Scheduled Broadcast

        public IObservable<PaginationResult<ScheduledBroadcast>> GetScheduledBroadcasts(PaginationRequest request)
        {
            return _apiService.GetScheduledBroadcastsAsync(request).ToObservable();
        }

        public IObservable<ScheduledBroadcast> GetScheduledBroadcastById(string id)
        {
            return _apiService.GetScheduledBroadcastByIdAsync(id).ToObservable();
        }

        #endregion

        #region Videos

        public IObservable<PaginationResult<Video>> GetVideos(PaginationRequest request)
        {
            return _apiService.GetVideosAsync(request).ToObservable();
        }

        public IObservable<Video> GetVideoBySlug(string videoSlug)
        {
            return _apiService.GetVideoBySlugAsync(videoSlug).ToObservable();
        }

        #endregion

        #region User

        public IObservable<UserPrivate> GetCurrentUser()
        {
            return _apiService.GetCurrentUserAsync().ToObservable();
        }

        public IObservable<IEnumerable<User>> GetFollowers()
        {
            return _apiService.GetFollowersAsync().ToObservable();
        }

        public IObservable<IEnumerable<User>> GetFollows()
        {
            return _apiService.GetFollowsAsync().ToObservable();
        }

        public IObservable<XmppAccount> GetXmppAccount()
        {
            return _apiService.GetXmppAccountAsync().ToObservable();
        }

        public IObservable<PaginationResult<LiveStreamPrivate>> GetUserLivestreams(PaginationRequest request)
        {
            return _apiService.GetUserLivestreamsAsync(request).ToObservable();
        }

        public IObservable<PaginationResult<LiveStreamPrivate>> GetUserLivestreamsOnAir(PaginationRequest request)
        {
            return _apiService.GetUserLivestreamsOnAirAsync(request).ToObservable();
        }

        public IObservable<PaginationResult<Video>> GetUserVideos(PaginationRequest request)
        {
            return _apiService.GetUserVideosAsync(request).ToObservable();
        }

        public IObservable<IEnumerable<Video>> GetUserLatestVideos()
        {
            return _apiService.GetUserLatestVideosAsync().ToObservable();
        }

        #endregion
    }
}
