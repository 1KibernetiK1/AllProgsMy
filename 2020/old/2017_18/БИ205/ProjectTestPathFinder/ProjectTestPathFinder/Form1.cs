using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryPathFinder;

namespace ProjectTestPathFinder
{
    public partial class Form1 : Form
    {
        private int[,] map = new int[50, 50];
        private PathFinder finder;

        private List<LibraryPathFinder.Point> path;

        private LibraryPathFinder.Point start,end;

        private void SetGridProperties()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
        }

        private void BuildGridForMap()
        {
            dataGridView1.Columns.Clear();
            //----------------------------
            for (int i = 0; i < map.GetLength(1); i++)
            {
                dataGridView1.Columns.Add("","");
                dataGridView1.Columns[i].Width = 10;
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Height = 10;
            }
        }

        public Form1()
        {
            InitializeComponent();
            map[1, 1] = -1;
            map[1, 2] = -1;
            map[1, 3] = -1;
            BuildGridForMap();
            SetGridProperties();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int x = e.ColumnIndex;
            int y = e.RowIndex;
            int val = map[y, x];
            switch (val)
            {
                case 1:
                    e.CellStyle.BackColor = Color.Blue;
                    break;
                case 0: e.CellStyle.BackColor = Color.White;
                    break;
                case -1:
                    e.CellStyle.BackColor = Color.DarkGray;
                    break;
                case -2:
                    e.CellStyle.BackColor = Color.Red;
                    break;
                case -3:
                    e.CellStyle.BackColor = Color.Green;
                    break;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            map[row, col] = -1;
        }

        private void btnSetWall_Click(object sender, EventArgs e)
        {
            var cells = dataGridView1.SelectedCells;
            foreach (DataGridViewCell c in cells)
            {
                int row = c.RowIndex;
                int col = c.ColumnIndex;
                map[row, col] = -1;
                c.Selected = false;
            }
        }

        private void btnSetStart_Click(object sender, EventArgs e)
        {
            var cell = dataGridView1.SelectedCells[0];
            if (start != null)
            {
                map[start.Y, start.X] = 0;
            }
            int x = cell.ColumnIndex;
            int y = cell.RowIndex;
            start = new LibraryPathFinder.Point(x,y);
            map[y, x] = -2;
            cell.Selected = false;
            dataGridView1.Refresh();
        }

        private void btnSetEnd_Click(object sender, EventArgs e)
        {
            var cell = dataGridView1.SelectedCells[0];
            if (end != null)
            {
                map[end.Y, end.X] = 0;
            }
            int x = cell.ColumnIndex;
            int y = cell.RowIndex;
            end = new LibraryPathFinder.Point(x, y);
            map[y, x] = -3;
            cell.Selected = false;
            dataGridView1.Refresh();
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                foreach (var p in path)
                {
                    if (map[p.Y, p.X] == 1)
                        map[p.Y, p.X] = 0;
                }
            }
            map[end.Y, end.X] = 0;
            finder = new PathFinder(map);
            path = finder.GetPath(start, end);
            //-----
            foreach (var p in path)
            {
                map[p.Y, p.X] = 1;
            }
            dataGridView1.Refresh();
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            var cells = dataGridView1.SelectedCells;
            foreach (DataGridViewCell c in cells)
            {
                int row = c.RowIndex;
                int col = c.ColumnIndex;
                map[row, col] = 0;
                c.Selected = false;
            }
        }
    }
}
