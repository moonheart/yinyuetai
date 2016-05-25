using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yinyuetai
{
    public class MvInfo
    {
        private string _mvPageAddress;
        private string _mvhdVideoUrl;
        private string _mvhcVideoUrl;
        private string _mvheVideoUrl;
        private string _mvThumbAddress;
        private string _mvTitle;
        private string _mvSinger;
        private string _mvPlayTimes;

        /// <summary>
        /// MV网页播放地址
        /// </summary>
        public string MvPageAddress
        {
            get { return _mvPageAddress; }
            set { _mvPageAddress = value; }
        }

        /// <summary>
        /// 高清地址
        /// </summary>
        public string MvhdVideoUrl
        {
            get { return _mvhdVideoUrl; }
            set { _mvhdVideoUrl = value; }
        }

        /// <summary>
        /// MV封面地址
        /// </summary>
        public string MvThumbAddress
        {
            get { return _mvThumbAddress; }
            set { _mvThumbAddress = value; }
        }

        /// <summary>
        /// MV名字
        /// </summary>
        public string MvTitle
        {
            get { return _mvTitle; }
            set { _mvTitle = value; }
        }

        /// <summary>
        /// 歌手名字
        /// </summary>
        public string MvSinger
        {
            get { return _mvSinger; }
            set { _mvSinger = value; }
        }

        /// <summary>
        /// MV播放次数
        /// </summary>
        public string MvPlayTimes
        {
            get { return _mvPlayTimes; }
            set { _mvPlayTimes = value; }
        }
        /// <summary>
        /// 超清地址
        /// </summary>
        public string MvheVideoUrl
        {
            get { return _mvheVideoUrl; }
            set { _mvheVideoUrl = value; }
        }
        /// <summary>
        /// 流畅地址
        /// </summary>
        public string MvhcVideoUrl
        {
            get { return _mvhcVideoUrl; }
            set { _mvhcVideoUrl = value; }
        }
    }
}
