using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet.Games". При необходимости она может быть перемещена или удалена.
            this.gamesTableAdapter.Fill(this.myDataBaseDataSet.Games);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet.Manufacturer". При необходимости она может быть перемещена или удалена.
            this.manufacturerTableAdapter.Fill(this.myDataBaseDataSet.Manufacturer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet.Games". При необходимости она может быть перемещена или удалена.
            this.gamesTableAdapter.Fill(this.myDataBaseDataSet.Games);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet.Manufacturer". При необходимости она может быть перемещена или удалена.
            this.manufacturerTableAdapter.Fill(this.myDataBaseDataSet.Manufacturer);

        }
    }
}
