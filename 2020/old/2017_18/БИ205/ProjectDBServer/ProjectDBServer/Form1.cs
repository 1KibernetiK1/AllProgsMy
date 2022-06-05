using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBServer
{
    public partial class Form1 : Form
    {
        private DataManager _dm;
        private string _sringCon= 
         @"Data Source=(LocalDB)\MSSQLLocalDB;"
        + @"AttachDbFilename=D:\Visual Studio 2010\Bi205\ProjectDBServer\SmartDb.mdf;"
        + @"Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
            _dm = new DataManager(_sringCon);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dm.LoadBrands();
            dataGridView1.DataSource = _dm.ViewBrands;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            txt = txt.Trim();
            _dm.AddBrand(txt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // _dm.SynchonizeBrands();
            /*
            _dm.SyncBrandsV2();
            dataGridView1.DataSource = _dm.ViewBrands;*/
            // _dm.SyncBrandsV3();
            _dm.SyncBransV4();
        }
    }
}
