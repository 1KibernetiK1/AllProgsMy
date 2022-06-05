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
    public partial class Form1 : Form
    {
        private string _connectionString =
            @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=MyDatabase2022;Integrated Security=True";

        private DataManager _dataManager;

        private DataView studentTableView;

        public Form1()
        {
            InitializeComponent();
            _dataManager = new DataManager(_connectionString);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _dataManager.LoadTable( EnumTables.AcademicGroup );
            dataGridView1.DataSource = _dataManager.GetTableView(EnumTables.AcademicGroup);
            // настройки сетки
            dataGridView1.Columns["AcademicGroupId"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "Название группы";
            dataGridView1.Columns["Year"].HeaderText = "Год поступления";
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //--------------------------------------------------------------------
            _dataManager.LoadTable(EnumTables.Student);
            studentTableView = _dataManager.GetTableView(EnumTables.Student);
            dataGridView2.DataSource = studentTableView;
            //------------------------------------------
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            textBox1.TextChanged += TextBox1_TextChanged;
            /*
            dataGridView2.DataSource = _dataManager.GetTableView(EnumTables.Student);
            */
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            studentTableView.RowFilter = $"[Lastname] LIKE '%{text}%' OR [Firstname] LIKE '%{text}%'";
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            string groupId = row.Cells["AcademicGroupId"].Value.ToString();
            studentTableView.RowFilter = "AcademicGroupId = "+groupId;
        }

        private void btnEditGroups_Click(object sender, EventArgs e)
        {
            var wnd = new FormEditAcademicGroup(_dataManager);
            wnd.ShowDialog();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            var wnd = new FormEditStudents(_dataManager);
            wnd.ShowDialog();
        }
    }
}
