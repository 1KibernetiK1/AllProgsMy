using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//--------------------------
using System.Text.RegularExpressions;

namespace ProjectDemoRegularExp
{
    public partial class Form1 : Form
    {
        private string p1 = "[0-9]+";


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex rx = new Regex(p1);
            string text = textBox1.Text;
            var m = rx.Matches(text);
            listBox1.Items.Clear();
            foreach (Match item in m)
            {
                listBox1.Items.Add(item.Value);
            }
        }
    }
}
