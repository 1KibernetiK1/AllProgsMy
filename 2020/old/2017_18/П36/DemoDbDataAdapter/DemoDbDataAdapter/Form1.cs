using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDbDataAdapter
{
    public partial class Form1 : Form
    {
        private DatabaseManager dm;

        private string stConnect =
            @"Data Source=(LocalDB)\MSSQLLocalDB;"
           +@"AttachDbFilename='D:\Visual Studio 2010\2018\п36\GamesDb.mdf';"
           +@"Integrated Security=True;"
           +@"Connect Timeout=30";

        public Form1()
        {
            InitializeComponent();
            dm = new DatabaseManager(stConnect);
            LoadData();
        }

        private void LoadData()
        {
            dm.LoadTable("Genres");
            dataGridView1.DataSource = dm.Genres;
            //-----------------------------------
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = dm.Genres;
            //------------------------------
            dm.LoadTable("Games");
            dataGridView2.DataSource =
                dm.Games;
            dm.Filter(1);
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdGenre = (int)comboBox1.SelectedValue;
            dm.Filter(IdGenre);
        }
    }
}
