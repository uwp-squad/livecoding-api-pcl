using LivecodingApi.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.UniversalWindows.Services
{
    public interface ILivecodingApiService
    {
        #region Properties

        /// <summary>
        /// Token used by the Livecoding API to provide access to the entire API
        /// </summary>
        string Token { get; set; }

        #endregion
    }

    public class LivecodingApiService : ILivecodingApiService
    {
        #region Fields

        private readonly string _baseApiAddress = $"{Constants.ApiBaseUrl}{Constants.ApiVersion}";

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
    }
}
