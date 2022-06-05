using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;

namespace Dyste
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=MyDataBase;Integrated Security=True";

        private Datamanager _datamanager;

        public Form1()
        {
            InitializeComponent();
            _datamanager = new Datamanager(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _datamanager.LoadTableGroups();
            dataGridView1.DataSource = _datamanager.GetTableGroupsView();
        }
    }
}
