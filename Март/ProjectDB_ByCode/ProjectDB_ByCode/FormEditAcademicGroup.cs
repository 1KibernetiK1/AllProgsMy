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
    public partial class FormEditAcademicGroup : Form
    {
        private DataManager _dataManager;
        private string _selectedGroupId;

        public FormEditAcademicGroup(DataManager dataManager)
        {
            InitializeComponent();
            _dataManager = dataManager;
            dataGridView1.DataSource = _dataManager.GetTableView(EnumTables.AcademicGroup);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.ReadOnly = true;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            _selectedGroupId = row.Cells["AcademicGroupId"].Value.ToString();

            textBoxAcademicGroup.Text = row.Cells["Name"].Value.ToString();
            numericUpDownYear.Value = (int) row.Cells["Year"].Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGroupId))
            {
                MessageBox.Show("Выберите сначала группу!");
                return;
            }
            _dataManager.RemoveAcademicGroup(_selectedGroupId);
            _selectedGroupId = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_dataManager.SaveChanges(EnumTables.AcademicGroup))
                MessageBox.Show("Saved!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = textBoxAcademicGroup.Text;
            int year = (int) numericUpDownYear.Value;

            _dataManager.AddAcademicGroup(title, year);
            _selectedGroupId = null;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGroupId))
            {
                MessageBox.Show("Выберите сначала группу!");
                return;
            }

            string title = textBoxAcademicGroup.Text;
            int year = (int)numericUpDownYear.Value;

            _dataManager.ChangeAcademicGroup(_selectedGroupId, title, year);
            _selectedGroupId = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _dataManager.LoadTable(EnumTables.AcademicGroup);
            _selectedGroupId = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
