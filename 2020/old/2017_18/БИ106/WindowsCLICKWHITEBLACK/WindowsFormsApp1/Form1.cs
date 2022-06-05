using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool IsWhiteStep = true;

        private bool IsSelected = false;
        private Label lblSelected;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void LabelClick(object sender, EventArgs e)
        {
            lblSelected = (Label)sender;
            if (lblSelected.Text == "WHITE")
            {
                if (IsWhiteStep == false)
                    return;
            } else if (lblSelected.Text == "BLACK")
            {
                if (IsWhiteStep == true)
                    return;
            }
            IsSelected = true;
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsSelected)
            {
                lblSelected.Location = e.Location;
                IsWhiteStep = !IsWhiteStep;
                IsSelected = false;
            }
        }
    }
}
