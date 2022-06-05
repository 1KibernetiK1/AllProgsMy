using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDB_ByCode
{
    public partial class FormEditStudents : Form
    {
        private DataManager _dataManager;
        private string _selectedStudentsId;

        public FormEditStudents(DataManager dataManager)
        {
            InitializeComponent();
            _dataManager = dataManager;
            dataGridView1.DataSource = _dataManager.GetTableView(EnumTables.Student);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.ReadOnly = true;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            _selectedStudentsId = row.Cells["StudentId"].Value.ToString();

            textBoxStudentsName.Text = row.Cells["Firstname"].Value.ToString();
            textBoxStudentsLastName.Text = row.Cells["Lastname"].Value.ToString();
            numericUpDownYear.Value = (int)row.Cells["AcademicGroupId"].Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxStudentsName.Text;
            string LastName = textBoxStudentsLastName.Text;
            int idGroup = (int)numericUpDownYear.Value;

            _dataManager.AddStudentsGroup(name, LastName, idGroup);
            _selectedStudentsId = null;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedStudentsId))
            {
                MessageBox.Show("Выберите сначала Студента!");
                return;
            }

            string name = textBoxStudentsName.Text;
            string LastName = textBoxStudentsLastName.Text;
            int idGroup = (int)numericUpDownYear.Value;

            _dataManager.ChangeStudentGroup(_selectedStudentsId, name, LastName, idGroup);
            _selectedStudentsId = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedStudentsId))
            {
                MessageBox.Show("Выберите сначала Студента!");
                return;
            }
            _dataManager.RemoveStudentGroup(_selectedStudentsId);
            _selectedStudentsId = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_dataManager.SaveChanges(EnumTables.Student))
                MessageBox.Show("Saved!");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _dataManager.LoadTable(EnumTables.Student);
            _selectedStudentsId = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
