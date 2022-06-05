using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectRegions
{
    public partial class Form1 : Form
    {
        private GraphicsPath gp;
        private Region rgn;
        private bool IsDrag = false;
        private Point pt;
        private void CreateRegion()
        {
            gp = new GraphicsPath();
            gp.AddArc(10,10,150,70,0,60);
            gp.AddLine(10,10,30,200);
            gp.CloseFigure();
            rgn = new Region(gp);
        }

        public Form1()
        {
            InitializeComponent();
            CreateRegion();
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrag)
            {
                int dx = e.X - pt.X;
                int dy = e.Y - pt.Y;
                rgn.Translate(dx, dy);
                pt = e.Location;
                this.Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            IsDrag = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (rgn.IsVisible(e.Location))
            { // мышка на регионе
                IsDrag = true;
                pt = e.Location;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRegion(Brushes.Yellow, rgn);
            e.Graphics.DrawPath(Pens.Blue, gp);
        }
    }
}
