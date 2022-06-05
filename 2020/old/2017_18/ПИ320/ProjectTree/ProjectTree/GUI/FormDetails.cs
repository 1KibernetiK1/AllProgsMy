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
    public partial class FormDetails : Form
    {
        private Student student;

        public Student StudentDetails
        {
            get {
                return student;
            }
            set {
                student = value;
                textBoxAge.Text = student.Age + "";
                textBoxName.Text = student.Name;
                textBoxLastname.Text = student.Lastname;
            }
        }


        public FormDetails()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            student.Age = int.Parse(textBoxAge.Text);
            student.Name = textBoxName.Text;
            student.Lastname = textBoxLastname.Text;
        }
    }
}
