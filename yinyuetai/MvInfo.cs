using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yinyuetai
{
    public class MvInfo
    {
        /// <summary>
        /// MV网页播放地址
        /// </summary>
        public string MvPageAddress { get; set; }

        /// <summary>
        /// 高清地址
        /// </summary>
        public string MvhdVideoUrl { get; set; }

        /// <summary>
        /// MV封面地址
        /// </summary>
        public string MvThumbAddress { get; set; }

        /// <summary>
        /// MV名字
        /// </summary>
        public string MvTitle { get; set; }

        /// <summary>
        /// 歌手名字
        /// </summary>
        public string MvSinger { get; set; }

        /// <summary>
        /// MV播放次数
        /// </summary>
        public string MvPlayTimes { get; set; }

        /// <summary>
        /// 超清地址
        /// </summary>
        public string MvheVideoUrl { get; set; }

        /// <summary>
        /// 流畅地址
        /// </summary>
        public string MvhcVideoUrl { get; set; }
    }
}
