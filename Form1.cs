using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace OutputExcel
{   
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {          
            int pageSize = int.Parse(numericUpDown_DY.Value.ToString());
            if (pageSize > 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    btnStart_DY.Enabled = false;
                    progressBar1_DY.Visible = true;
                    Item item = new Item("DY", pageSize, "skfzg00000", "Aa123456");
                    backgroundWorker1.RunWorkerAsync(item);
                }
            }          
            
        }
        private void btnStart_JQ_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(numericUpDown_JQ.Value.ToString());
            if (pageSize > 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    btnStart_JQ.Enabled = false;
                    progressBar1_JQ.Visible = true;
                    Item item = new Item("JQ", pageSize, "SKF China0", "Bb123456");
                    backgroundWorker1.RunWorkerAsync(item);
                }
            }          
        }

        private void btnStart_NS_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(numericUpDown_NS.Value.ToString());
            if (pageSize > 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    btnStart_NS.Enabled = false;
                    progressBar1_NS.Visible = true;
                    Item item = new Item("NS", pageSize, "skf0000000", "Init1234");
                    backgroundWorker1.RunWorkerAsync(item);
                }
            }          
        }

        private void btnStart_WH_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(numericUpDown_WH.Value.ToString());
            if (pageSize > 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    btnStart_WH.Enabled = false;
                    progressBar1_WH.Visible = true;
                    Item item = new Item("WH", pageSize, "skfxs00000", "Bb123456");
                    backgroundWorker1.RunWorkerAsync(item);
                }
            }          
        }

        #region 通用eschedule

        private void start(Item item, DoWorkEventArgs e)
        {
            String userName = item.userName;
            String pwd = item.pwd;
            String postUrl = "http://eschedule.shanghaigm.com/" + item .name+ "/common_/login.do";
            MyHttpClient clientPost = new MyHttpClient(postUrl, null, true);
            clientPost.PostingData.Add("loginId", userName);
            clientPost.PostingData.Add("pwd", pwd);
            clientPost.PostingData.Add("method", "dunsLogin");
            string html = clientPost.GetString();
            if (html.Contains("common/index.jsp"))
            {
                backgroundWorker1.ReportProgress(10, item.name);
                DataTable dt = null;
                for (int i = 1; i <= item.pageSize; i++)
                {
                    String url = "http://eschedule.shanghaigm.com/" + item.name + "/pus_/pusSearch.do?method=listAllStatusPus&__SORT_TAG_NAME_SORT_COLUMN=__cGxhbkFycml2ZVRpbWU=__&__SORT_TAG_NAME_SORT_ORDER=DESC&com.sgm.common.web.PageBreakerTagCURRENT_PAGE_SIZE_NAME=20&com.sgm.common.web.PageBreakerTagCURRENT_PAGE_SIZE_NAME=20&com.sgm.common.web.PageBreakerTagCURRENT_PAGE_NUM_NAME=" + i;
                    MyHttpClient client = new MyHttpClient(url, clientPost.Context);
                    client.Context.Referer = url;
                    html = client.GetString();
                    int startIndex = html.IndexOf("<!-- iterator begin -->");
                    int endPos = html.IndexOf("</table>", startIndex);
                    String tableHtml = html.Substring(startIndex + 25, endPos - startIndex - 12).TrimStart().TrimEnd();
                    GetDataTable(i, tableHtml, client, item.name, ref dt);

                    backgroundWorker1.ReportProgress((i * 100) / item.pageSize, item.name);
                    Thread.Sleep(0);
                }
                ReturnItem re = new ReturnItem();
                re.itemName = item.name;
                re.dt = dt;
                e.Result = re;
            }
        }

        private DataTable GetDataTable(int index, string data, MyHttpClient client, String itemName, ref DataTable dt)
        {
            Boolean isFristflag = true;
            bool createHeadflag = false;
            if (dt == null)
            {
                dt = new DataTable();
                createHeadflag = true;
            }

            using (TextReader reader = new StringReader(data))
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(reader);
                HtmlNodeCollection trList = doc.DocumentNode.SelectNodes("//tr");

                String info = "";
                foreach (HtmlNode trNode in trList)
                {
                    DataTable detailDT = new DataTable();
                    detailDT.Columns.Add("零件号");
                    detailDT.Columns.Add("承诺数量");

                    HtmlNodeCollection tdList = trNode.SelectNodes("td");
                    if (isFristflag && createHeadflag)
                    {
                        dt.Columns.Add("页码");
                        dt.Columns.Add(tdList[1].InnerText.Trim());
                        dt.Columns.Add("pus#");
                        dt.Columns.Add("零件号");
                        dt.Columns.Add("承诺数量");
                        dt.Columns.Add("交货说明");                        
                        dt.Columns.Add(tdList[4].InnerText.Trim());
                        dt.Columns.Add(tdList[5].InnerText.Trim());
                        dt.Columns.Add(tdList[6].InnerText.Trim());
                        dt.Columns.Add(tdList[7].InnerText.Trim());
                        dt.Columns.Add(tdList[8].InnerText.Trim());
                        dt.Columns.Add(tdList[9].InnerText.Trim());
                        dt.Columns.Add(tdList[10].InnerText.Trim());
                        dt.Columns.Add(tdList[11].InnerText.Trim());
                        dt.Columns.Add(tdList[12].InnerText.Trim());
                        dt.Columns.Add(tdList[13].InnerText.Trim());
                        if (tdList.Count == 15)
                        {
                            dt.Columns.Add(tdList[14].InnerText.Trim());
                        }
                        isFristflag = false;
                        createHeadflag = false;
                    }
                    else if ((tdList.Count == 15 ||tdList.Count == 14)&& !isFristflag)
                    {
                        String orderId = "";
                        String txt = tdList[3].InnerHtml;
                        int startIndex = txt.IndexOf("showDetail");
                        if (startIndex > 0)
                        {
                            int endIndex = txt.IndexOf("');");
                            orderId = txt.Substring(startIndex + 12, endIndex - startIndex - 12);
                            string url = "http://eschedule.shanghaigm.com/" + itemName + "/pus_/pus.do?method=showPusDetail&sid=" + orderId;
                            client.Url = url;
                            client.Reset();
                            String txtDetail = client.GetString();

                            getDetail(txtDetail, ref info, ref detailDT);
                            // 交货说明
                            // 零件清单 零件号 承诺数量
                        }
                        foreach (DataRow row in detailDT.Rows)
                        {
                            if (tdList.Count == 15)
                            {
                                dt.Rows.Add("第" + index + "页", tdList[1].InnerText.Trim(), tdList[2].InnerText.Trim(),
                                row[0].ToString(), row[1].ToString(), info, tdList[4].InnerText.Trim(),
                                tdList[5].InnerText.Trim(), tdList[6].InnerText.Trim(),
                                tdList[7].InnerText.Trim(), tdList[8].InnerText.Trim(),
                                tdList[9].InnerText.Trim(), tdList[10].InnerText.Trim(),
                                tdList[11].InnerText.Trim(), tdList[12].InnerText.Trim(),
                                tdList[13].InnerText.Trim().Replace("&nbsp;", " "), tdList[14].InnerText.Trim().Replace("&nbsp;", " "));
                            }
                            else
                            {
                                dt.Rows.Add("第" + index + "页", tdList[1].InnerText.Trim(), tdList[2].InnerText.Trim(),
                                    row[0].ToString(), row[1].ToString(), info, tdList[4].InnerText.Trim(),
                                    tdList[5].InnerText.Trim(), tdList[6].InnerText.Trim(),
                                    tdList[7].InnerText.Trim(), tdList[8].InnerText.Trim(),
                                    tdList[9].InnerText.Trim(), tdList[10].InnerText.Trim(),
                                    tdList[11].InnerText.Trim(), tdList[12].InnerText.Trim(),
                                    tdList[13].InnerText.Trim().Replace("&nbsp;", " "));
                            }
                        }
                    }
                    isFristflag = false;
                }

                reader.Close();
            }
            return dt;
        }

        private void getDetail(string txtDetail, ref String info, ref DataTable detailDataTable)
        {
            //交货说明
             int startIndex2 = txtDetail.IndexOf("Delivery Note");
             int endPos2 = txtDetail.IndexOf("</TD>", startIndex2+40);
             info = txtDetail.Substring(startIndex2 + 63, endPos2 - startIndex2 - 63).Trim();

             StringBuilder sb = new StringBuilder();
            int startIndex1 = txtDetail.IndexOf("table_double_head");
            int endPos1 = txtDetail.IndexOf("tableend", startIndex1);
            String tableHtml = txtDetail.Substring(startIndex1 - 11, endPos1 - startIndex1 - 11).TrimStart().TrimEnd();
            //DataTable dt = new DataTable();
            using (TextReader reader = new StringReader(tableHtml))
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(reader);
                HtmlNodeCollection trList = doc.DocumentNode.SelectNodes("//tr");
                Boolean flag = true;
                foreach (HtmlNode trNode in trList)
                {
                    HtmlNodeCollection tdList = trNode.SelectNodes("td");
                    if (flag)
                    {
                        flag = false;
                    }
                    else if (tdList.Count == 12)
                    {
                        detailDataTable.Rows.Add(tdList[1].InnerText.Trim(), tdList[4].InnerText.Trim());
                    }
                }
                reader.Close();
            }
        }
        #endregion
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Item item = (Item)e.Argument;
            //1.登陆
            start(item, e);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            String itemName = (String)e.UserState;
            switch (itemName)
            {
                case "DY":
                    btnStart_DY.Text = e.ProgressPercentage + "%";
                    progressBar1_DY.Value = e.ProgressPercentage;
                    break;
                case "JQ":
                    btnStart_JQ.Text = e.ProgressPercentage + "%";
                    progressBar1_JQ.Value = e.ProgressPercentage;
                    break;
                case "WH":
                    btnStart_WH.Text = e.ProgressPercentage + "%";
                    progressBar1_WH.Value = e.ProgressPercentage;
                    break;
                case "NS":
                    btnStart_NS.Text = e.ProgressPercentage + "%";
                    progressBar1_NS.Value = e.ProgressPercentage;
                    break;
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ReturnItem re = (ReturnItem)e.Result;
            ExcelHelper.DataTableToExcel(re.dt, re.itemName);
            switch (re.itemName)
            {
                case "DY":
                    btnStart_DY.Enabled = true;
                    btnStart_DY.Text = "开始导入";
                    break;
                case "JQ":
                    btnStart_JQ.Enabled = true;
                    btnStart_JQ.Text = "开始导入";
                    break;
                case "WH":
                    btnStart_WH.Enabled = true;
                    btnStart_WH.Text = "开始导入";
                    break;
                case "NS":
                    btnStart_NS.Enabled = true;
                    btnStart_NS.Text = "开始导入";
                    break;
            }            
        }

        private void buttonDY_Click(object sender, EventArgs e)
        {
            open("DY.exe");
        }

        private void buttonWH_Click(object sender, EventArgs e)
        {
            open("WH.exe");
        }

        private void buttonJQ_Click(object sender, EventArgs e)
        {
            open("JQ.exe");
        }

        private void buttonNS_Click(object sender, EventArgs e)
        {
            open("NS.exe");
        }
        private void open(String name)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = name;// @"路径\exe的文件名";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Minimized;
            Process pro = Process.Start(info);
            pro.WaitForExit(); 
        }
    }
}
