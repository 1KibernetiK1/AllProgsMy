using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSelections
{
    public partial class Form1 : Form
    {
        private string stDayOfWeek = "";

        public Form1()
        {
            InitializeComponent();
            foreach (var item in groupBox3.Controls)
            {
                RadioButton rb = (RadioButton)item;
                rb.CheckedChanged += Rb_CheckedChanged;
            }
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked) stDayOfWeek = rb.Text;
            label1.Text = "День " + stDayOfWeek;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stPayment = "";
            // 1) вариант проверка выбора
            if (radioButton1.Checked)
                stPayment = "Наличка";
            else if (radioButton2.Checked)
                stPayment = "Кредитка";
            else if (radioButton3.Checked)
                stPayment = "Инет-кошелёк";
            else if (radioButton4.Checked)
                stPayment = "Биткоины";
            //-----------------------------
            textBox1.Text = stPayment;
            // 2) вариант с помощью списка
            string stDelivery = "";
            foreach (var item in groupBox2.Controls)
            {
                RadioButton rb = (RadioButton)item;
                if (rb.Checked)
                {
                    stDelivery = rb.Text;
                }
            }
            textBox1.Text += "\r\n" + stDelivery;
            textBox1.Text += "\r\n" + stDayOfWeek;
        }
    }
}
