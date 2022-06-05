using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGif
{
    public partial class FormPreviewAnimation : Form
    {
        private List<PictureBox> list;
        private int counter;

        public List<PictureBox> ListFrames
        {
            get { return list; }
            set { list = value; }
        }


        public FormPreviewAnimation()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += FormPreviewAnimation_Paint;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter == list.Count)
                counter = 0;
            this.Refresh();
        }

        private void FormPreviewAnimation_Paint(object sender, PaintEventArgs e)
        {
            if (list.Count == 0) return;
            Image img = list[counter].Image;
            e.Graphics.DrawImageUnscaled(img, 10, 10);
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
            if (list == null) return;
            timer1.Enabled = !timer1.Enabled;
            btnPlayPause.Text = timer1.Enabled ?
                "Pause" : "Play";

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string title = textBoxGroup.Text;
            var group = new AnimationGroup();
            group.Title = title;
            int[] numbers = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                PictureBox pb = list[i];
                numbers[i] = (int) pb.Tag;
            }
            group.Numbers = numbers;
            DataManager.Add(group);
            MessageBox.Show("Готово!");
            Close();
        }
    }
}
