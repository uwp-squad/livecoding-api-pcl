using LivecodingApi.Exceptions;
using LivecodingApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Security.Authentication.Web;
using Windows.Web.Http.Headers;

namespace LivecodingApi.Helpers
{
    internal static class AuthHelper
    {
        #region Properties

        /// <summary>
        /// Redirect URL when authenticate
        /// </summary>
        public static string RedirectUrl = "http://localhost";

        #endregion

        #region Methods

        public static string RetrieveToken(WebAuthenticationResult result, string oauthKey, string oauthSecret)
        {
            if (result.ResponseStatus == WebAuthenticationStatus.Success)
            {
                return GetAccessToken(result.ResponseData);
            }
            if (result.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
            {
                throw new ApiAuthException(WebAuthenticationStatus.ErrorHttp);
            }
            if (result.ResponseStatus == WebAuthenticationStatus.UserCancel)
            {
                throw new ApiAuthException(WebAuthenticationStatus.UserCancel);
            }

            return null;
        }

        private static string GetAccessToken(string responseUrl)
        {
            string[] splitResultResponse = responseUrl.Split('&');
            string codeString = splitResultResponse.FirstOrDefault(value => value.Contains("access_token"));
            string[] splitCode = codeString.Split('=');
            return splitCode.Last();
        }

        #endregion
    }
}
