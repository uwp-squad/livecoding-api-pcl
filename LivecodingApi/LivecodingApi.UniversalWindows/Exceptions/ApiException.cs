using System;
#if __IOS__ || __ANDROID__ || NET45
using System.Net;
#endif
#if NETFX_CORE
using Windows.Web.Http;
#endif

namespace LivecodingApi.Exceptions
{
    public class ApiException : Exception
    {
        #region Properties

        private readonly string _message;
        /// <summary>
        /// The content message of the error
        /// </summary>
        public override string Message { get { return _message; } }

        /// <summary>
        /// The HTTP status code associated with the repsonse
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        #endregion

        #region Constructors

        public ApiException() { }

        public ApiException(string message)
        {
            _message = message;
        }

        public ApiException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public ApiException(string message, HttpStatusCode statusCode)
        {
            _message = message;
            StatusCode = statusCode;
        }

        #endregion
    }
}
