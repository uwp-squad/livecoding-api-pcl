using LivecodingApi.Configuration;
using LivecodingApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="search">Search coding categories (based on fields 'name', 'slug' or 'sort')</param>
        /// <returns></returns>
        Task<PaginationResult<CodingCategory>> GetCodingCategoriesAsync(string search = null);

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
        /// <param name="search">Search livestreams (based on fields 'title', 'description' or 'tags')</param>
        /// <returns></returns>
        Task<PaginationResult<LiveStream>> GetLiveStreamsAsync(string search = null);

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
        Task<LiveStream> GetCurrentLivestreamOfUserAsync(string userSlug);

        #endregion

        #region Languages

        /// <summary>
        /// Returns all languages used in the site (human languages)
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Site_Languages_list)
        /// </summary>
        /// <param name="search">Search languages (based on field 'name')</param>
        /// <returns></returns>
        Task<PaginationResult<SiteLanguage>> GetLanguagesAsync(string search = null);

        /// <summary>
        /// Returns a language by its ISO code
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Site_Languages_retrieve)
        /// </summary>
        /// <param name="iso">Iso code (ex: "fr")</param>
        /// <returns></returns>
        Task<SiteLanguage> GetLanguageByIsoCodeAsync(string iso);

        #endregion

        #region Scheduled Broadcast

        /// <summary>
        /// Returns all scheduled broadcasts
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Scheduled_Broadcast_list)
        /// </summary>
        /// <returns></returns>
        Task<PaginationResult<ScheduledBroadcast>> GetScheduledBroadcastsAsync();

        /// <summary>
        /// Returns a scheduled broadcast by its id
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Scheduled_Broadcast_retrieve)
        /// </summary>
        /// <param name="id">Id of the scheduled broadcast</param>
        /// <returns></returns>
        Task<ScheduledBroadcast> GetScheduledBroadcastByIdAsync(string id);

        #endregion

        #region Videos

        /// <summary>
        /// Returns all videos
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Video_list)
        /// </summary>
        /// <returns></returns>
        Task<PaginationResult<Video>> GetVideosAsync();

        /// <summary>
        /// Returns a video by its slug
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Video_retrieve)
        /// </summary>
        /// <param name="slug">Slug of the video</param>
        /// <returns></returns>
        Task<Video> GetVideoBySlugAsync(string videoSlug);

        #endregion

        #region User

        /// <summary>
        /// Returns current user info
        /// (https://www.livecoding.tv/developer/documentation/#!/v1/Account_User_list)
        /// </summary>
        /// <returns></returns>
        Task<User> GetCurrentUserAsync();

        #endregion
    }
}
