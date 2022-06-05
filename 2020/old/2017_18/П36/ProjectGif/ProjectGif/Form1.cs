using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGif
{
    public partial class Form1 : Form
    {
        private PictureBox[,] frames;
        private List<PictureBox> selected;
        private List<ToolStripMenuItem> menuItems;

        public Form1()
        {
            InitializeComponent();
            menuItems = new List<ToolStripMenuItem>();
            DataManager.GroupAdded += DataManager_GroupAdded;
            DataManager.GroupRefresh += DataManager_GroupRefresh;
        }

        private void DataManager_GroupRefresh(AnimationGroup group)
        {
            ToolStripMenuItem item = null;
            foreach (var m in menuItems)
            {
                if (m.Text == group.Title)
                {
                    item = m;
                    break;
                }
            }
            if (item != null)
            {
                item.Tag = group;
            }

            foreach (var pb in selected)
            {
                pb.BackColor = Color.Gray;
                pb.Enabled = false;
            }
            selected.Clear();
        }

        private void DataManager_GroupAdded(AnimationGroup group)
        {
            var item = new ToolStripMenuItem();
            menuItems.Add(item);
            item.Click += Item_Click;
            item.Text = group.Title;
            item.Tag = group;
            анимацииToolStripMenuItem
                .DropDownItems.Add(item);
            foreach (var pb in selected)
            {
                pb.BackColor = Color.Gray;
                pb.Enabled = false;
            }
            selected.Clear();
        }

        private void Item_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            var group = (AnimationGroup) item.Tag;
            selected.Clear();
            int cols = frames.GetLength(1);
            foreach (var n in group.Numbers)
            {
                int r = n / cols;
                int c = n % cols;
                var pb = frames[r, c];
                pb.BackColor = Color.LightGreen;
                pb.Enabled = true;
                selected.Add(pb);
            }
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Gif |*.gif";
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                LoadGif(openFileDialog1.FileName);
            }
        }

        private void LoadGif(string fileName)
        {
            selected = new List<PictureBox>();
            panel1.Controls.Clear();
            var image = Image.FromFile(fileName);
            // сколько кадров в гиф-анимации
            int count = image.GetFrameCount(FrameDimension.Time);
            // кол-во строк и столбцов
            double root = Math.Sqrt(count);
            int cols = (int)root;
            int rows = (int) Math.Ceiling((float)count / cols);
            // массив для хранения кадров
            frames = new PictureBox[rows, cols];
            int w = image.Width;
            int h = image.Height;
            for (int i = 0; i < count; i++)
            {
                // выбираем активный кадр из гиф
                image.SelectActiveFrame(FrameDimension.Time, i);
                // посчитаем строку и столбец
                int r = i / cols;
                int c = i % cols;
                // размеры кадра
                var pb = new PictureBox();
                pb.Tag = i;
                pb.Click += Pb_Click;
                pb.Width = w;
                pb.Height = h;
                pb.Left = c * w;
                pb.Top = r * h;
                var bmp = new Bitmap(w,h);
                var gr = Graphics.FromImage(bmp);
                gr.DrawImageUnscaled(image, 0, 0);
                pb.Image = bmp;

                frames[r, c] = pb;
                panel1.Controls.Add(pb);
            }
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            var pb = (PictureBox) sender;
            pb.BackColor = Color.LightGreen;
            int i = selected.IndexOf(pb);
            if (i < 0)
            {
                selected.Add(pb);
            } else
            {
                selected.RemoveAt(i);
                pb.BackColor = Color.Transparent;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                var form = new FormPreviewAnimation();
                form.ListFrames = selected;
                form.ShowDialog();
            }
        }

        private void GroupMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
