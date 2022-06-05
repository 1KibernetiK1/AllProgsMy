using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDataSet
{
    public partial class Form1 : Form
    {
        private DatabaseManager _dm;

        public Form1()
        {
            InitializeComponent();
            _dm = new DatabaseManager();
            _dm.AddSomeData();
            _dm.CreateBinding();
            dataGridView1.DataSource = _dm.BindGroups;
            dataGridView2.DataSource = _dm.BindStudents;
            comboBox1.DataSource = _dm.BindGroups;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Id";
            //----------------------------
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = 
                DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            string title = textBoxGroup.Text;
            _dm.AddGroup(title);
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string name =
                textBoxName.Text;
            string lastname =
                textBoxLastname.Text;
            int IdGroup = (int)
                comboBox1.SelectedValue;
            _dm.AddStudent(name,lastname, IdGroup);
        }
    }
}
