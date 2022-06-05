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
    public partial class FormListStudents : Form
    {
        public FormListStudents()
        {
            InitializeComponent();
            DataManager.CreateFile();
            this.FormClosed += FormListStudents_FormClosed;
        }

        private void FormListStudents_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataManager.CloseFile();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var stud = new Student();
            var form = new FormDetails();
            form.StudentDetails = stud;
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                DataManager.AddRecordFile(stud);
                listBox1.Items.Add(stud);
            }
        }
    }
}
