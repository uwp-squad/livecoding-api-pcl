using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public static class AuthenticationScope
    {
        /// <summary>
        /// REQUIRED Read basic public profile information
        /// </summary>
        public static string Read = "read";

        /// <summary>
        /// OPTIONAL Play live streams and videos for you
        /// </summary>
        public static string ReadViewer = "read:viewer";

        /// <summary>
        /// OPTIONAL Read your personal information
        /// </summary>
        public static string ReadUser = "read:user";

        /// <summary>
        /// OPTIONAL Read private channel information
        /// </summary>
        public static string ReadChannel = "read:channel";

        /// <summary>
        /// OPTIONAL Access chat on your behalf
        /// </summary>
        public static string Chat = "chat";
    }
}
