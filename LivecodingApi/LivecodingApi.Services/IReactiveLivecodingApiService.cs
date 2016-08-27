using LivecodingApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Services
{
    public interface IReactiveLivecodingApiService
    {
        #region Properties

        /// <summary>
        /// Token used by the Livecoding API to provide access to the entire API
        /// </summary>
        string Token { get; }

        #endregion

        #region Authentication
        
        /// <summary>
        /// Execute login process through OAuth2 authentication mechanism
        /// </summary>
        /// <param name="oauthKey">OAuth client key (provided by livecoding website)</param>
        /// <param name="oauthSecret">OAuth secret key (provided by livecoding website)</param>
        /// <param name="scopes">List of scopes (AuthenticationScope)</param>
        /// <returns>true: login success / false: login failed / null: exception occured</returns>
        IObservable<bool?> Login(string oauthKey, string oauthSecret, string[] scopes);

        #endregion

        #region Coding Categories

        /// <summary>
        /// Returns all coding categories
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Coding_Categories_list)
        /// </summary>
        /// <param name="search">Search coding categories (based on fields 'name', 'slug' or 'sort')</param>
        /// <returns></returns>
        IObservable<PaginationResult<CodingCategory>> GetCodingCategories(PaginationRequest request);

        /// <summary>
        /// Returns a coding category based on his name
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Coding_Categories_retrieve)
        /// </summary>
        /// <param name="name">Name of the category</param>
        /// <returns></returns>
        IObservable<CodingCategory> GetCodingCategoryByName(string name);

        #endregion

        #region Livestreams

        /// <summary>
        /// Returns all livestreams
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Live_Stream_list)
        /// </summary>
        /// <param name="search">Search livestreams (based on fields 'title', 'description' or 'tags')</param>
        /// <returns></returns>
        IObservable<PaginationResult<LiveStream>> GetLiveStreams(PaginationRequest request);

        /// <summary>
        /// Returns all livestreams currently on air
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Live_Stream_onair)
        /// </summary>
        /// <returns></returns>
        IObservable<PaginationResult<LiveStream>> GetLiveStreamsOnAir(PaginationRequest request);

        /// <summary>
        /// Returns livestream of a user
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Live_Stream_retrieve)
        /// </summary>
        /// <param name="userSlug">Username slug</param>
        /// <returns></returns>
        IObservable<LiveStream> GetCurrentLivestreamOfUser(string userSlug);

        #endregion

        #region Languages

        /// <summary>
        /// Returns all languages used in the site (human languages)
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Site_Languages_list)
        /// </summary>
        /// <param name="search">Search languages (based on field 'name')</param>
        /// <returns></returns>
        IObservable<PaginationResult<SiteLanguage>> GetLanguages(PaginationRequest request);

        /// <summary>
        /// Returns a language by its ISO code
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Site_Languages_retrieve)
        /// </summary>
        /// <param name="iso">Iso code (ex: "fr")</param>
        /// <returns></returns>
        IObservable<SiteLanguage> GetLanguageByIsoCode(string iso);

        #endregion

        #region Scheduled Broadcast

        /// <summary>
        /// Returns all scheduled broadcasts
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Scheduled_Broadcast_list)
        /// </summary>
        /// <returns></returns>
        IObservable<PaginationResult<ScheduledBroadcast>> GetScheduledBroadcasts(PaginationRequest request);

        /// <summary>
        /// Returns a scheduled broadcast by its id
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Scheduled_Broadcast_retrieve)
        /// </summary>
        /// <param name="id">Id of the scheduled broadcast</param>
        /// <returns></returns>
        IObservable<ScheduledBroadcast> GetScheduledBroadcastById(string id);

        #endregion

        #region Videos

        /// <summary>
        /// Returns all videos
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Video_list)
        /// </summary>
        /// <returns></returns>
        IObservable<PaginationResult<Video>> GetVideos(PaginationRequest request);

        /// <summary>
        /// Returns a video by its slug
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Video_retrieve)
        /// </summary>
        /// <param name="slug">Slug of the video</param>
        /// <returns></returns>
        IObservable<Video> GetVideoBySlug(string videoSlug);

        #endregion

        #region User

        /// <summary>
        /// Returns current user info
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Account_User_list)
        /// </summary>
        /// <returns></returns>
        IObservable<UserPrivate> GetCurrentUser();

        /// <summary>
        /// Returns current user followers
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Account_User_followers)
        /// </summary>
        /// <returns></returns>
        IObservable<IEnumerable<User>> GetFollowers();

        /// <summary>
        /// Returns current user lsit of followed users
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Account_User_follows)
        /// </summary>
        /// <returns></returns>
        IObservable<IEnumerable<User>> GetFollows();

        /// <summary>
        /// Returns current user XMPP account information (to access the chat)
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Xmpp_Account_list)
        /// </summary>
        /// <returns></returns>
        IObservable<XmppAccount> GetXmppAccount();

        /// <summary>
        /// Get list of user channels (currently, only one is in the list at the same time)
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Account_Live_Stream_list)
        /// </summary>
        /// <returns></returns>
        IObservable<PaginationResult<LiveStreamPrivate>> GetUserLivestreams(PaginationRequest request);

        /// <summary>
        /// Get list of user channels currently on air (currently, only one is in the list at the same time)
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Account_Live_Stream_onair)
        /// </summary>
        /// <returns></returns>
        IObservable<PaginationResult<LiveStreamPrivate>> GetUserLivestreamsOnAir(PaginationRequest request);

        /// <summary>
        /// Returns current user videos
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Account_Video_list)
        /// </summary>
        /// <returns></returns>
        IObservable<PaginationResult<Video>> GetUserVideos(PaginationRequest request);

        /// <summary>
        /// Returns current user latest videos
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Account_Video_latest)
        /// </summary>
        /// <returns></returns>
        IObservable<IEnumerable<Video>> GetUserLatestVideos();

        #endregion
    }
}
