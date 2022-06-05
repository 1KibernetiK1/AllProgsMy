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
    public partial class Formreduct : Form
    {
        private DataManager _dataManager;

        private string _selectedStudioId;

        public Formreduct(DataManager dataManager)
        {
            InitializeComponent();
            _dataManager = dataManager;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];
            string str = row.Cells["StudioId"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedStudioId))
            {
                MessageBox.Show("Выберите сначала группу");
                return;
            }
            _dataManager.RemoveStudio(_selectedStudioId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wnd = new Form1
        }
    }
}
