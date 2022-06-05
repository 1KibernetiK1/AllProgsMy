using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDbMySQL
{
    public partial class Form1 : Form
    {
        private DataManager dm;

        public Form1()
        {
            InitializeComponent();
            dm = new DataManager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
                dm.LoadTable("groups");
            dm.ServerInsert("groups");
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            string strGroup = textBoxGroup.Text;
            dm.AddGroup(strGroup);
        }
    }
}
