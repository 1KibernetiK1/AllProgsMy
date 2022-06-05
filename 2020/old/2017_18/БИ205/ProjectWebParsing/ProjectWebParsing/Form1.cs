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

namespace ProjectWebParsing
{
    public partial class Form1 : Form
    {
        public string GetPage(string url)
        {
            string html = "";
            try
            {
                // 1) запрос на сервер (http)
                var req = WebRequest.Create(url);
                // 2) ожидаем ответ сервера
                WebResponse res = req.GetResponse();
                // 3) загружаем контент
                Stream stream = res.GetResponseStream();
                // 4) читаем построчно
                var sr = new StreamReader(stream);
                html = sr.ReadToEnd();
                // 5) закрываем потоки
                sr.Close();
                stream.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return html;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            string stUrl = textBox1.Text;
            // stUrl = "http://" + stUrl;
            string html = GetPage(stUrl);
            textBox2.Text = html;
            ParsePage(html);
            */
            string stUrl = "http://cbr.ru/currency_base/daily.aspx?date_req=";
            DateTime t1 = new DateTime(2018,1,1);
            DateTime t2 = new DateTime(2018,4,20);
            while(t1 < t2)
            {
                string stDate = t1.ToShortDateString();
                textBox2.Text += stDate + "\r\n";
                string url = stUrl + stDate;
                string html = GetPage(url);
                string dollar = ParsePage(html);
                textBox2.Text += dollar + "\r\n";
                textBox2.Update();
                t1 = t1.AddDays(1);
            }
        }

        public string ParsePage(string html)
        {
            string marker = "<td>Доллар США</td>";
            int i1 = html.IndexOf(marker);
            if (i1 < 0)
            {
                MessageBox.Show("not found!");
                return "";
            }
            i1 += marker.Length; 
            int i2 = html.IndexOf("</tr>",i1);
            string part = html.Substring(i1, i2-i1);
            part = part.Replace("<td>", "");
            part = part.Replace("</td>", "");
            // MessageBox.Show(part);
            return part;
        }
    }
}
