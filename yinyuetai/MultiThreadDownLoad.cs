using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace yinyuetai
{
    public class MultiThreadDownLoad
    {
        #region 变量
        private int _threadNum;             //线程数量
        private long _fileSize;             //文件大小
        private string _extName;            //文件扩展名
        private string _fileUrl;            //文件地址
        private string _fileName;           //文件名
        private string _savePath;           //保存路径
        private short _threadCompleteNum;   //线程完成数量
        private bool _isComplete;           //是否完成
        private volatile int _downloadSize; //当前下载大小(实时的)
        public Thread[] _thread;           //线程数组
        private List<string> _tempFiles = new List<string>();
        private List<List<int>> readft = new List<List<int>>();//存放每个线程读取的起始和结束位置
        private object locker = new object();
        #endregion

        #region 属性
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }

        public long FileSize
        {
            get
            {
                return _fileSize;
            }
        }

        public int DownloadSize
        {
            get
            {
                return _downloadSize;
            }
        }

        public bool IsComplete
        {
            get
            {
                return _isComplete;
            }
            set
            {
                _isComplete = value;
            }
        }

        public int ThreadNum
        {
            get
            {
                return _threadNum;
            }
        }

        public string SavePath
        {
            get
            {
                return _savePath;
            }
            set
            {
                _savePath = value;
            }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="threahNum">线程数量</param>
        /// <param name="fileUrl">文件Url路径</param>
        /// <param name="savePath">本地保存路径</param>
        public MultiThreadDownLoad(int threahNum, string fileUrl, string savePath)
        {
            this._threadNum = threahNum;
            this._thread = new Thread[threahNum];
            this._fileUrl = fileUrl;
            this._savePath = savePath;
        }

        //_serverUrl为http://xxx.xx/xx.dll形式
        //_localFile为\\Program File\xx.dll形式 PS:终端路径

        public void Start()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_fileUrl);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                _extName = response.ResponseUri.ToString().Substring(response.ResponseUri.ToString().LastIndexOf('.'));//获取真实扩展名
                _fileSize = response.ContentLength;

                int singelNum = (int)(_fileSize / _threadNum);      //平均分配
                int remainder = (int)(_fileSize % _threadNum);      //获取剩余的
                for (int i = 0; i < _threadNum; i++)
                {
                    List<int> range = new List<int>();
                    range.Add(i * singelNum);
                    if (remainder != 0 && (_threadNum - 1) == i)    //剩余的交给最后一个线程
                        range.Add(i * singelNum + singelNum + remainder - 1);
                    else
                        range.Add(i * singelNum + singelNum - 1);
                    readft.Add(range);
                    _thread[i] = new Thread(new ThreadStart(Download));
                    _thread[i].Name = i.ToString();
                    _thread[i].Start();
                    request.Abort();
                }
            }

        }

        private void Download()
        {
            Stream httpFileStream = null, localFileStram = null;
            try
            {
                string tmpFileBlock = String.Format(@"{0}\{1}_{2}.dat", _savePath, FileName, Thread.CurrentThread.Name);
                _tempFiles.Add(tmpFileBlock);
                HttpWebRequest httprequest = (HttpWebRequest)HttpWebRequest.Create(_fileUrl);
                httprequest.AddRange(readft[Convert.ToInt32(Thread.CurrentThread.Name)][0], readft[Convert.ToInt32(Thread.CurrentThread.Name)][1]);
                HttpWebResponse httpresponse = (HttpWebResponse)httprequest.GetResponse();
                httpFileStream = httpresponse.GetResponseStream();
                localFileStram = new FileStream(tmpFileBlock, FileMode.Create);
                byte[] by = new byte[1024];
                int getByteSize = httpFileStream.Read(by, 0, 1024);           //Read方法将返回读入by变量中的总字节数
                while (getByteSize > 0)
                {
                    Thread.Sleep(20);
                    lock (locker) _downloadSize += getByteSize;
                    localFileStram.Write(by, 0, getByteSize);
                    getByteSize = httpFileStream.Read(by, 0, 1024);
                }
                lock (locker)
                    _threadCompleteNum++;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (httpFileStream != null) httpFileStream.Close();
                if (localFileStram != null) localFileStram.Close();
            }
            if (_threadCompleteNum == _threadNum)
            {
                Complete();
                _isComplete = true;
            }
        }

        /// <summary>
        /// 下载完成后合并文件块
        /// </summary>
        private void Complete()
        {
            Stream mergeFile = null;
            BinaryWriter AddWriter = null;
            try
            {
                mergeFile = new FileStream(String.Format(@"{0}\{1}", _savePath, FileName), FileMode.Create);
                AddWriter = new BinaryWriter(mergeFile);
                foreach (string file in _tempFiles)
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        BinaryReader TempReader = new BinaryReader(fs);
                        AddWriter.Write(TempReader.ReadBytes((int)fs.Length));
                        TempReader.Close();
                    }
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                AddWriter.Close();
                mergeFile.Close();
            }

        }
    }
}
