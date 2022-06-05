using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//-------------------------
using System.IO;
using System.Net;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace ProjectWebGrabber
{
    public partial class Form1 : Form
    {
        private List<float> _list;

        public Form1()
        {
            InitializeComponent();
            _list = new List<float>();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string stUrl = @"http://cbr.ru/currency_base/daily.aspx?date_req=";  // = textBox1.Text;
            DateTime time1 = dateTimePicker1.Value;  // new DateTime(2017, 1, 1);
            DateTime time2 = dateTimePicker2.Value; // new DateTime(2018, 4, 13);
            while(time1 < time2)
            {
                string stDay = time1.ToShortDateString();
                string html = GetHtml(stUrl + stDay);
                float money = GetCurrency(html, "Доллар США");
                // textBox2.Text += stDay + " " + money.ToString() + "\r\n";
                _list.Add(money);
                time1 = time1.AddDays(7);
            }
            // строим график
            Series series = chart1.Series[0];
            series.ChartType = SeriesChartType.Point;
            for (int i = 0; i < _list.Count; i++)
            {
                series.Points.AddY(_list[i]);
            }
            chart1.ChartAreas[0].AxisY.Minimum = 50;
        }

        private float GetCurrency(string html, string marker)
        {
            string Marker = $"<td>{marker}</td>";
            int i = html.IndexOf(Marker);
            i += Marker.Length;
            int i2 = html.IndexOf("</td>", i);
            string part = html.Substring(i, i2 - i);
            part = part.Replace("<td>", "");
            return float.Parse(part);
        }

        private string GetHtml(string stUrl)
        {
            string html = "  price=\"\"  ";
            while (true)
            {
                try
                {
                    // 1) отправляем веб-запрос по адресу
                    WebRequest req = WebRequest.Create(stUrl);
                    // 2) забираем ответ с сервера
                    WebResponse res = req.GetResponse();
                    // 3) считываем всю информацию из канала
                    Stream stream = res.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    html = sr.ReadToEnd();
                    sr.Close(); stream.Close();
                    break;
                }
                catch (Exception ex)
                {
                    Thread.Sleep(2000);
                }
            }
            return html;
        }
    }
}
