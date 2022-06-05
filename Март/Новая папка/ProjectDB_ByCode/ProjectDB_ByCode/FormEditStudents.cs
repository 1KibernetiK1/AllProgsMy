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
        private readonly DataManager _dataManager;
        private DataView _studentsView;
        private DataView _groupsView;
        private string _selectedGroupId;
        private string _selectedStudentId;

        public FormEditStudents(DataManager dataManager)
        {
            InitializeComponent();
            this._dataManager = dataManager;

            _studentsView = _dataManager
                .GetTableView(EnumTables.Student);

            _groupsView = _dataManager
                .GetTableView(EnumTables.AcademicGroup, "AcademicGroupId");

            dataGridView1.DataSource = _studentsView;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            comboBox1.DataSource = _groupsView;

            //юзеру показывает название группы
            comboBox1.DisplayMember = "Name";
            // но при этом выбираем Id группы
            comboBox1.ValueMember = "AcademicGroupId";

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;       

            var row = dataGridView1.SelectedRows[0];
            string groupID = row.Cells["AcademicGroupId"].Value.ToString();

            if (string.IsNullOrEmpty(groupID)) return;


            _selectedStudentId = row.Cells["StudentId"].Value.ToString();
            string firstName = row.Cells["FirstName"].Value.ToString();
            string lastName = row.Cells["LastName"].Value.ToString();

            textBoxFirstName.Text = firstName;
            LastName.Text = lastName;

            var rows = _groupsView.FindRows(new object[] { groupID});

            if (rows.Count() > 0)
            {
                string groupName = rows[0]["Name"].ToString();
                LastName.Text = groupName;
                LastName.ReadOnly = true;
            }

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedGroupId = comboBox1.SelectedValue.ToString();
            label2.Text = _selectedGroupId;
        }

        private void btnFilterGroup_Click(object sender, EventArgs e)
        {
            _studentsView.RowFilter = $"AcademicGroupId = {_selectedGroupId}";
        }

        private void btnAllGroups_Click(object sender, EventArgs e)
        {
            _studentsView.RowFilter = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedStudentId))
            {
                MessageBox.Show("OK");
            }

            _dataManager.RemoveStudent(_selectedStudentId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _dataManager.AddStudentId(textBoxFirstName.Text, LastName.Text, _selectedGroupId);
        }
    }
}
