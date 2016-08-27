using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Model
{
    public static class VideoFilteringField
    {
        /// <summary>
        /// 
        /// </summary>
        public static string Difficulty = "difficultylevel";

        /// <summary>
        /// 
        /// </summary>
        public static string Region = "region";

        /// <summary>
        /// 
        /// </summary>
        public static string CodingCategory = "coding__slug";

        /// <summary>
        /// 
        /// </summary>
        public static string Language = "language__name";
    }

    public static class LivestreamFilteringField
    {
        /// <summary>
        /// 
        /// </summary>
        public static string Livestream = "livestream";

        /// <summary>
        /// 
        /// </summary>
        public static string CodingCategory = "coding_category__slug";

        /// <summary>
        /// 
        /// </summary>
        public static string Difficulty = "coding_difficulty";
    }
}
