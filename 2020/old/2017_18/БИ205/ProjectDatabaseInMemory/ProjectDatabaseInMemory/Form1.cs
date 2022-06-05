using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabaseInMemory
{
    public partial class Form1 : Form
    {
        DataManager dm;

        public Form1()
        {
            InitializeComponent();
            dm = new DataManager();
            dm.MakeSomeData();
            dataGridView1.DataSource = dm.Master;
            dataGridView2.DataSource = dm.Slave;
            comboBox1.DataSource = dm.Master;
            comboBox1.DisplayMember = "Title";
            dataGridView1.ReadOnly = true;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            string text = textBoxGroup.Text;
            text = text.Trim().ToUpper();
            dm.AddGroup(text);
        }
    }
}
