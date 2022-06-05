using ProjectTree.Data;
using ProjectTree.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTree.GUI
{
    public partial class FormViewRecordsOrder : Form
    {
        public FormViewRecordsOrder()
        {
            InitializeComponent();
            DataManager.OpenRead();
            this.FormClosing += MyFormClosing;
        }

        private void MyFormClosing(object sender, FormClosingEventArgs e)
        {
            DataManager.CloseFile();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Student stud = DataManager.NextRecord();
            if (stud == null)
            {
                MessageBox.Show("Файл закончен!");
            }
            else
            {
                listBox1.Items.Add(stud);
            }
        }
    }
}
