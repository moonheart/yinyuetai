using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Threading;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace yinyuetai
{
    public partial class MainForm : Form
    {
        #region 字段
        private string yinyuetaiApi = "http://www.yinyuetai.com/api/info/get-video-urls";
        private readonly List<MvInfo> _mvList = new List<MvInfo>();
        int _downloading;
        private string _savePath = "";
        private bool isCancel = false;
        private Dictionary<long, string> files = new Dictionary<long, string>();

        delegate void SetProgressBarMax(ProgressBar progress, int msx);
        delegate void SetProgressBarNow(ProgressBar progress, int now);
        delegate void SetLableText(Label lablel, string text);
        delegate void AppendTextBoxText(TextBox textbox, string text);

        private delegate void SetControlEnabled(Control control, bool isEnabled);

        SetProgressBarMax _setProgressBarMax;
        SetProgressBarNow _setProgressBarNow;
        SetLableText _setLableText;
        AppendTextBoxText _appendTextBoxText;
        private SetControlEnabled _setControlEnabled;

        #endregion
        public MainForm()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 获取html字符串
        /// </summary>
        /// <param name="strUrl">网页地址</param>
        /// <param name="paramDictionary">Get请求参数</param>
        /// <returns>html字符串</returns>
        private string GetHtmlString(string strUrl, IDictionary<string, string> paramDictionary)
        {
            if (string.IsNullOrEmpty(strUrl))
                return "";
            if (paramDictionary != null && paramDictionary.Count > 0)
            {
                strUrl += "?";
                foreach (var param in paramDictionary)
                {
                    strUrl += param.Key + "=" + param.Value + "&";
                }
                strUrl = strUrl.Substring(0, strUrl.Length - 1);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            //request.BeginGetResponse(ReadCallback, request);

            try
            {
                Application.DoEvents();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                if (myResponseStream != null)
                {
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                    var strRet = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();

                    return strRet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // ignored
            }
            return "";
        }


        /// <summary>
        /// 获取信息按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            var strUrl = txtPageAddress.Text.Trim();

            if (string.IsNullOrEmpty(strUrl))
            {
                MessageBox.Show("请输入地址");
                return;
            }
            string reg = @"http://v.yinyuetai.com/video/\d*";

            new Thread(() =>
            {
                Invoke(_setControlEnabled, btnGetInfo, false);
                if (Regex.IsMatch(strUrl, reg))
                {
                    Regex reggg = new Regex(reg);
                    var ccc = reggg.Match(strUrl);
                    GetOneMvInfo(ccc.ToString());
                }
                else
                {
                    GetMvInfoList(strUrl);
                }
                Invoke(_setControlEnabled, btnGetInfo, true);

            }).Start();

        }



        private void ShowOneMvInfo(MvInfo mvInfo)
        {
            string msg = @"观看地址：" + mvInfo.MvPageAddress + "\r\n";
            msg += @"超清下载地址：" + mvInfo.MvheVideoUrl + "\r\n";
            msg += @"高清下载地址：" + mvInfo.MvhdVideoUrl + "\r\n";
            msg += @"流畅下载地址：" + mvInfo.MvhcVideoUrl + "\r\n";
            msg += @"图标地址：" + mvInfo.MvThumbAddress + "\r\n";
            msg += @"标题：" + mvInfo.MvTitle + "\r\n";
            msg += @"歌手：" + mvInfo.MvSinger + "\r\n";
            msg += @"播放次数：" + mvInfo.MvPlayTimes + "\r\n\r\n";
            Invoke(_appendTextBoxText, txtAddress, msg);
            Invoke(_setLableText, lblMessage, @"本次共获取到" + _mvList.Count + @"个MV的信息");
        }

        /// <summary>
        /// 获取MV真实下载地址列表
        /// </summary>
        /// <param name="pageUrl">饭团MV页面地址</param>
        /// <returns>MV真实下载地址列表</returns>
        private void GetMvInfoList(string pageUrl)
        {
            _mvList.Clear();

            var page = string.IsNullOrEmpty(txtPage.Text.Trim()) ? 0 : int.Parse(txtPage.Text.Trim());
            if (page == 0)
            {
                string htmlString = GetHtmlString(pageUrl, null);
                while (!string.IsNullOrEmpty(htmlString))
                {
                    HtmlNode node = FindMvListNode(htmlString);

                    var htmlNodes = node.Elements("li");

                    foreach (HtmlNode htmlNode in htmlNodes)
                    {
                        if (htmlNode.HasChildNodes)
                        {
                            var mvInfo = GetMvInfoByNode(htmlNode);
                            _mvList.Add(mvInfo);
                            ShowOneMvInfo(mvInfo);
                        }
                    }
                    //_mvList.AddRange(mvInfos);
                    htmlString = GetHtmlString(GetNextPageUrl(htmlString), null);
                }
            }
            else
            {
                string htmlString = GetHtmlString(pageUrl, null);
                while (page > 0)
                {
                    if (!string.IsNullOrEmpty(htmlString))
                    {
                        HtmlNode node = FindMvListNode(htmlString);

                        var htmlNodes = node.Elements("li");

                        foreach (HtmlNode htmlNode in htmlNodes)
                        {
                            if (htmlNode.HasChildNodes)
                            {
                                var mvInfo = GetMvInfoByNode(htmlNode);
                                _mvList.Add(mvInfo);
                                ShowOneMvInfo(mvInfo);
                            }
                        }
                        //_mvList.AddRange(mvInfos);
                        htmlString = GetHtmlString(GetNextPageUrl(htmlString), null);
                    }
                    else
                    {
                        break;
                    }

                    page--;
                }
            }

        }

        private HtmlNode FindMvListNode(string htmlString)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlString);
            //var node = doc.GetElementbyId("mv_list");
            var node = doc.DocumentNode.SelectSingleNode("//div[@class='mv_list']");
            node = node.Element("ul");
            return node;
        }

        /// <summary>
        /// 在饭团MV页面通过Node分析MV信息
        /// </summary>
        /// <param name="htmlNode">用于查找的Node</param>
        /// <returns>MV信息</returns>
        private MvInfo GetMvInfoByNode(HtmlNode htmlNode)
        {
            MvInfo mvInfo = new MvInfo();

            IEnumerable<HtmlNode> nodeDivCollection = htmlNode.Descendants("div");
            var divCollection = nodeDivCollection as IList<HtmlNode> ?? nodeDivCollection.ToList();
            if (divCollection.Any())
            {
                var tempNode1 = divCollection.Last();
                mvInfo.MvPlayTimes = tempNode1.InnerText.Replace("播放", "").Replace("次", "");
            }

            IEnumerable<HtmlNode> nodeACollection = htmlNode.Descendants("a");

            var aCollection = nodeACollection as IList<HtmlNode> ?? nodeACollection.ToList();
            if (aCollection.Any())
            {
                var tempNode1 = aCollection.ElementAt(0);
                mvInfo.MvTitle = tempNode1.GetAttributeValue("title", "");
                if (mvInfo.MvTitle == "")
                {
                    //var pt = "title=\".+ \" href";
                    var pt = "title=\".+\" href";
                    var va = Regex.Match(tempNode1.OuterHtml, pt).Value;
                    mvInfo.MvTitle = va.TrimEnd("\" href".ToArray()).TrimStart("title=\"".ToArray())
                        ;
                }
                mvInfo.MvTitle = mvInfo.MvTitle.Replace("\"", "").Replace("=", " ").Replace("/", " ").Replace("\\", "/").Trim();
                mvInfo.MvPageAddress = tempNode1.GetAttributeValue("href", "");

                var tempNode2 = aCollection.ElementAt(2);
                mvInfo.MvSinger = tempNode2.InnerText.Replace("\n", "").Replace("\t", "");
            }

            IEnumerable<HtmlNode> nodeImgCollection = htmlNode.Descendants("img");
            var imgCollection = nodeImgCollection as IList<HtmlNode> ?? nodeImgCollection.ToList();
            if (imgCollection.Any())
            {
                var tempNode = imgCollection.ElementAt(0);
                mvInfo.MvThumbAddress = tempNode.GetAttributeValue("src", "");
            }

            List<string> addressList = GetMvDownloadAdress(mvInfo.MvPageAddress);

            mvInfo.MvheVideoUrl = addressList[0];
            mvInfo.MvhdVideoUrl = addressList[1];
            mvInfo.MvhcVideoUrl = addressList[2];

            return mvInfo;
        }
        /// <summary>
        /// MV播放页面的视频地址
        /// </summary>
        /// <param name="pageUrl">页面地址</param>
        /// <returns>MV信息</returns>
        private void GetOneMvInfo(string pageUrl)
        {
            MvInfo mvInfo = new MvInfo();

            List<string> addressList = GetMvDownloadAdress(pageUrl);

            mvInfo.MvheVideoUrl = addressList[0];
            mvInfo.MvhdVideoUrl = addressList[1];
            mvInfo.MvhcVideoUrl = addressList[2];

            _mvList.Clear();
            _mvList.Add(mvInfo);

            _mvList.Add(mvInfo);
        }

        /// <summary>
        /// 通过音悦台API获取MV真实视频下载地址
        /// </summary>
        /// <param name="pageAddress">MV视频网页地址</param>
        /// <returns>MV视频真实下载地址</returns>
        private List<string> GetMvDownloadAdress(string pageAddress)
        {
            List<string> mvDownloadAddressList = new List<string>();

            IDictionary<string, string> iDictionary = new Dictionary<string, string>();
            iDictionary.Add("videoId", GetVideoId(pageAddress));
            string jsonString = GetHtmlString(yinyuetaiApi, iDictionary);

            mvDownloadAddressList = GetMvDownloadAdressByJson(jsonString);

            return mvDownloadAddressList;
        }

        private string GetVideoId(string pageAddress)
        {
            string videoId = "";
            if (!string.IsNullOrEmpty(pageAddress))
            {
                var ccc = pageAddress.Split('/');
                videoId = ccc[ccc.Length - 1];
            }
            return videoId;
        }

        /// <summary>
        /// 通过Json解析下载链接诶
        /// </summary>
        /// <param name="jsonString">用于解析的Json字符串</param>
        /// <returns>下载连接列表</returns>
        private List<string> GetMvDownloadAdressByJson(string jsonString)
        {
            List<string> mvAddressList = new List<string>()
            {
                "",
                "",
                ""
            };
            JObject jObject = JObject.Parse(jsonString);

            if (jObject["error"].ToString().ToLower() == "false")
            {
                mvAddressList[0] = PageUrlToDownUrl((jObject["heVideoUrl"] ?? "").ToString());
                mvAddressList[1] = PageUrlToDownUrl((jObject["hdVideoUrl"] ?? "").ToString());
                mvAddressList[2] = PageUrlToDownUrl((jObject["hcVideoUrl"] ?? "").ToString());
            }
            return mvAddressList;
        }

        private string PageUrlToDownUrl(string pageUrl)
        {
            if (!string.IsNullOrEmpty(pageUrl))
            {
                pageUrl = pageUrl.Replace("\u003d", "=");
                pageUrl = pageUrl.Replace("\u0026", "&");
                pageUrl += "&ptp=mv&rd=yinyuetai.com";
            }
            return pageUrl;
        }

        private void btnCopyLinks_Click(object sender, EventArgs e)
        {
            if (_mvList.Count < 1)
            {
                MessageBox.Show("请先获取信息！");
                return;
            }
            string resolve = "";

            if (rbHd.Checked)
                resolve = "hd";
            else if (rbHc.Checked)
                resolve = "hc";
            else if (rbHe.Checked)
                resolve = "he";

            List<string> linkList = _mvList.Select(mvInfo => GetResolveLink(mvInfo, ref resolve)).ToList();

            string clipString = "";
            int scess = 0;
            foreach (string s in linkList)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    clipString += s + "\r\n";
                    scess++;
                }
            }

            try
            {
                Clipboard.SetText(clipString);
                MessageBox.Show("复制成功，本次共复制" + scess + "条");
            }
            catch (Exception ex)
            {
                MessageBox.Show("复制失败：" + ex.Message);
            }
        }

        private string GetResolveLink(MvInfo mvInfo, ref string resolve)
        {
            string resolveLink = "";
            switch (resolve)
            {
                case "he":
                    if (!string.IsNullOrEmpty(mvInfo.MvheVideoUrl))
                    {
                        resolveLink = mvInfo.MvheVideoUrl;
                        resolve = "he";
                    }
                    else if (!string.IsNullOrEmpty(mvInfo.MvhdVideoUrl))
                    {
                        resolveLink = mvInfo.MvhdVideoUrl;
                        resolve = "hd";
                    }
                    else
                    {
                        resolveLink = mvInfo.MvhcVideoUrl;
                        resolve = "hc";
                    }
                    break;
                case "hd":
                    if (!string.IsNullOrEmpty(mvInfo.MvhdVideoUrl))
                    {
                        resolveLink = mvInfo.MvhdVideoUrl;
                        resolve = "hd";
                    }
                    else
                    {
                        resolveLink = mvInfo.MvhcVideoUrl;
                        resolve = "hc";
                    }
                    break;
                case "hc":
                    if (!string.IsNullOrEmpty(mvInfo.MvhcVideoUrl))
                    {
                        resolveLink = mvInfo.MvhcVideoUrl;
                        resolve = "hc";
                    }
                    break;
            }

            return resolveLink;
        }

        /// <summary>        
        /// c#,.net 下载文件        
        /// </summary>        
        /// <param name="url">下载文件地址</param>       
        /// 
        /// <param name="filename">下载后的存放地址</param>        
        /// <param name="prog">用于显示的进度条</param>
        /// <param name="labellll"></param>        
        private void DownloadFile(string url, string filename, ProgressBar prog, Label labellll)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                byte[] bytes = new byte[1024];
                long totalBytes = response.ContentLength;
                if (chkCheck.Checked)
                {
                    foreach (var f in files)
                    {
                        if (f.Key == totalBytes)
                        {
                            if (f.Value != filename)
                            {
                                File.Move(f.Value, filename);
                                files.Remove(f.Key);
                                FileInfo file = new FileInfo(filename);
                                if (files.All(ff => ff.Key != file.Length && ff.Value != file.FullName))
                                {
                                    files.Add(file.Length, file.FullName);
                                }
                            }
                            break;
                        }
                    }
                    response.Close();
                    return;
                }
                BeginInvoke(_setProgressBarMax, prog, (int)(totalBytes / bytes.Length));
                //long existFileLenth = 0;
                if (File.Exists(filename))
                {
                    var len = File.ReadAllBytes(filename).Length;
                    //BeginInvoke(_setProgressBarNow, prog, len / bytes.Length);
                    if (len == totalBytes)
                    {
                        return;
                    }
                    else
                    {
                        //existFileLenth = len;
                        File.Delete(filename);
                    }
                }

                //if (prog != null)
                //{
                // prog.Maximum = (int)totalBytes;
                //}
                Stream resStream = response.GetResponseStream();
                if (resStream == null)
                    return;
                Stream localFileStream = new FileStream(filename, FileMode.OpenOrCreate);
                //if (existFileLenth > 0)
                //{
                //    localFileStream.Seek(existFileLenth, SeekOrigin.Current);
                //}
                long downloaded = 0;
                int osize = resStream.Read(bytes, 0, bytes.Length);

                while (osize > 0)
                {
                    localFileStream.Write(bytes, 0, osize);
                    downloaded += osize;
                    BeginInvoke(_setProgressBarNow, prog, (int)(downloaded / bytes.Length));
                    //Application.DoEvents();
                    osize = resStream.Read(bytes, 0, bytes.Length);
                    //Thread.Sleep(1);
                }
                localFileStream.Close();
                resStream.Close();
                BeginInvoke(_setLableText, labellll, "已完成 " + filename);
                BeginInvoke(_setProgressBarNow, prog, 0);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        /// <summary>
        /// 获取下一页
        /// </summary>
        /// <returns></returns>
        private string GetNextPageUrl(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.SelectSingleNode("//div[@class='page-nav']");
            if (node == null)
                return "";
            string pN = "href=\".+\">下一页";
            string res = Regex.Match(node.InnerHtml, pN).Value;
            if (string.IsNullOrEmpty(res))
                return "";
            res = res.TrimStart("href=\"".ToCharArray()).TrimEnd("\">下一页".ToCharArray());
            if (res.Contains("http://"))
                return res;
            return "http://www.yinyuetai.com" + res;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(_savePath))
                {
                    MessageBox.Show("请选择正确的路径");
                    return;
                }
                if (_mvList.Count == 0)
                {
                    MessageBox.Show("没有数据");
                    return;
                }
                string resolve = "";

                if (rbHd.Checked)
                    resolve = "hd";
                else if (rbHc.Checked)
                    resolve = "hc";
                else if (rbHe.Checked)
                    resolve = "he";
                CancellationTokenSource cancellation = new CancellationTokenSource();
                Thread t = new Thread(DoDownload);

                t.Start(resolve);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DoDisable(bool b)
        {
            Invoke(_setControlEnabled, txtSavePath, b);
            Invoke(_setControlEnabled, btnChooseSavePath, b);
            Invoke(_setControlEnabled, chkSingerFolder, b);
            Invoke(_setControlEnabled, btnDownload, b);
            Invoke(_setControlEnabled, btnStop, !b);
        }

        private void DoDownload(object obj)
        {
            DoDisable(false);
            string resolve = obj as string;

            foreach (var item in _mvList)
            {
                if (isCancel)
                {
                    isCancel = false;
                    break;
                }
                while (true)
                {
                    if (isCancel)
                    {
                        break;
                    }
                    if (_downloading >= 1)
                    {
                        Thread.Sleep(500);
                        continue;
                    }
                    string reso = resolve;
                    string downloadLink = GetResolveLink(item, ref reso);
                    if (string.IsNullOrEmpty(downloadLink))
                    {
                        break;
                    }
                    string path = _savePath.TrimEnd('\\');
                    var ext = downloadLink.IndexOf("flv", StringComparison.Ordinal) > -1 ? "flv" : "mp4";
                    string singerFolder = "";
                    if (chkSingerFolder.Checked)
                    {
                        singerFolder = item.MvSinger + @"\";
                    }
                    if (!Directory.Exists(string.Format(@"{0}\{1}", path, singerFolder)))
                    {
                        Directory.CreateDirectory(string.Format(@"{0}\{1}", path, singerFolder));
                    }
                    string fileName = string.Format(@"{4}\{5}{0} - {1} [{3}]_{6}.{2}", item.MvSinger, item.MvTitle, ext, reso, path, singerFolder, GetVideoId(item.MvPageAddress));


                    if (chkCheck.Checked)
                    {
                        string[] paths = Directory.GetFiles(string.Format(@"{0}\{1}", path, singerFolder));
                        foreach (var pa in paths)
                        {
                            var file = new FileInfo(pa);
                            if (files.All(ff => ff.Key != file.Length && ff.Value != file.FullName))
                            {
                                files.Add(file.Length, file.FullName);
                            }
                        }
                    }


                    BeginInvoke(_setLableText, lblCurrentTask, _mvList.IndexOf(item) + ":" + fileName);
                    Download(new object[] { downloadLink, fileName, progressBar1, lblCurrentTask });

                    //new Thread(Download).Start(new object[] { downloadLink, fileName, progressBar1, label2 });
                    //DownloadFile(downloadLink, fileName, progressBar1, label2);
                    Thread.Sleep(500);
                    break;
                }
            }
            DoDisable(true);
        }

        private void Download(object obj)
        {
            try
            {
                _downloading++;
                var arr = (object[])obj;
                DownloadFile((string)arr[0], (string)arr[1], (ProgressBar)arr[2], (Label)arr[3]);
                _downloading--;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 绑定委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            _setLableText = SetLableTextMethod;
            _setProgressBarMax = SetProgressBarMaxMethod;
            _setProgressBarNow = SetProgressBarNowMethod;
            _appendTextBoxText = AppendTextBoxTextMethod;
            _setControlEnabled = SetControlEnabledMethod;
            _savePath = txtSavePath.Text.Trim();
        }

        private void SetControlEnabledMethod(Control control, bool isenabled)
        {
            control.Enabled = isenabled;
        }

        private void AppendTextBoxTextMethod(TextBox textbox, string text)
        {
            textbox.AppendText(text);
        }

        private void SetProgressBarNowMethod(ProgressBar progress, int now)
        {
            try
            {
                progress.Value = now;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetProgressBarMaxMethod(ProgressBar progress, int msx)
        {
            try
            {
                progress.Maximum = msx;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetLableTextMethod(Label lablel, string text)
        {
            try
            {
                lablel.Text = text;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtSavePath_TextChanged(object sender, EventArgs e)
        {
            _savePath = txtSavePath.Text.Trim();

        }

        private void btnChooseSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            _savePath = dialog.SelectedPath;
            txtSavePath.Text = _savePath;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isCancel = true;

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MultiThreadDownLoad mtd = new MultiThreadDownLoad(8, @"http://hc.yinyuetai.com/uploads/videos/common/C940D459C6F2BDC94C6E87BF473341F1.flv?sc=f85fff23490b8641&br=762&vid=45641&aid=848&area=US&vst=0", @"C:\");
            mtd.FileName = "aaa";
            mtd.Start();
        }
    }
}
