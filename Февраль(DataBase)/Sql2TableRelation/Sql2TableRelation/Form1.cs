using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql2TableRelation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDatabase2022DataSet.Student". При необходимости она может быть перемещена или удалена.
            this.studentTableAdapter.Fill(this.myDatabase2022DataSet.Student);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDatabase2022DataSet.AcademicGroup". При необходимости она может быть перемещена или удалена.
            this.academicGroupTableAdapter.Fill(this.myDatabase2022DataSet.AcademicGroup);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDatabase2022DataSet.Student". При необходимости она может быть перемещена или удалена.
            this.studentTableAdapter.Fill(this.myDatabase2022DataSet.Student);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDatabase2022DataSet.AcademicGroup". При необходимости она может быть перемещена или удалена.
            this.academicGroupTableAdapter.Fill(this.myDatabase2022DataSet.AcademicGroup);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDatabase2022DataSet.Student". При необходимости она может быть перемещена или удалена.
            this.studentTableAdapter.Fill(this.myDatabase2022DataSet.Student);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDatabase2022DataSet.AcademicGroup". При необходимости она может быть перемещена или удалена.
            this.academicGroupTableAdapter.Fill(this.myDatabase2022DataSet.AcademicGroup);

        }
    }
}
