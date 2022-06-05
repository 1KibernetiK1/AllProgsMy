using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DZbdWF
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDBDataSet1.Students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.testDBDataSet1.Students);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDBDataSet1.ScoreStudent". При необходимости она может быть перемещена или удалена.
            this.scoreStudentTableAdapter.Fill(this.testDBDataSet1.ScoreStudent);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDBDataSet1.ScoreStudent". При необходимости она может быть перемещена или удалена.
            this.scoreStudentTableAdapter.Fill(this.testDBDataSet1.ScoreStudent);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDBDataSet1.Students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.testDBDataSet1.Students);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDBDataSet.Students". При необходимости она может быть перемещена или удалена.

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);

            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение установлено");
            }
        }

       
    }
}
