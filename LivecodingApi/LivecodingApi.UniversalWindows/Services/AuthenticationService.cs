using LivecodingApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace LivecodingApi.Services
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Execute login process through OAuth2 authentication mechanism
        /// </summary>
        /// <returns>true: login success / false: login failed / null: exception occured</returns>
        Task<bool?> LoginAsync(string oauthKey, string oauthSecret);

        /// <summary>
        /// Retrieve token to use Livecoding Api methods that requires a connected user
        /// </summary>
        /// <returns>The token</returns>
        Task<string> RetrieveTokenAsync();
    }

    /// <summary>
    /// Service used to finalize the authentication using Web Authentication Broker on Windows Store Apps
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private static string _token { get; set; }
        private static string[] _scopes = new string[]
        {
            "read",
            "read:viewer",
            "read:user",
            "read:channel",
            "chat"
        };

        #endregion


        #region Methods

        public async Task<bool?> LoginAsync(string oauthKey, string oauthSecret)
        {
            try
            {
                var state = Guid.NewGuid();
                string scopes = string.Join(" ", _scopes);

                string startUrl = $"https://www.livecoding.tv/o/authorize?scope={scopes}&state={state}&redirect_uri={AuthHelper.RedirectUrl}&response_type=token&client_id={oauthKey}";
                var startUri = new Uri(startUrl);
                var endUri = new Uri(AuthHelper.RedirectUrl);

                var webAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startUri, endUri);
                _token = AuthHelper.RetrieveToken(webAuthenticationResult, oauthKey, oauthSecret);
                return !string.IsNullOrWhiteSpace(_token);
            }
            catch
            {
                return null;
            }
        }

        public Task<string> RetrieveTokenAsync()
        {
            return Task.FromResult(_token);
        }

        #endregion
    }
}
