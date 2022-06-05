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
            @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=MyDataBase;Integrated Security=True";

        private DataManager _dataManager;

        private DataView studentsTableView;

        public Form1()
        {
            InitializeComponent();
            _dataManager = new DataManager(_connectionString);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _dataManager.LoadTable(EnumTables.Games);
            dataGridView1.DataSource = _dataManager.GetTableView(EnumTables.Games);

            // Настройки сетки
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["CreatedDate"].HeaderText = "Дата";
            dataGridView1.Columns["TitleName"].HeaderText = "Название";
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _dataManager.LoadTable(EnumTables.Manufacturer);
            studentsTableView = _dataManager.GetTableView(EnumTables.Manufacturer);
            dataGridView2.DataSource = studentsTableView;
            //dataGridView2.DataSource = _dataManager.GetTableView(EnumTables.Manufacturer);
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            studentsTableView.RowFilter = $" [Name] LIKE %{text}%";
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];
            string str = row.Cells["Id"].Value.ToString();

            studentsTableView.RowFilter = $"Id = {str}";
        }

        private void FilterForGrid2()
        {
            DataView tableView = _dataManager.GetTableView(EnumTables.Manufacturer);
            tableView.RowFilter = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

    }
}
