using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace MGProjectUserControl
{
    public partial class FormOptions : Form
    {
        private StartOptions _options;

        public StartOptions Options
        {
            get { return _options; }
            set { _options = value; }
        }


        public FormOptions()
        {
            InitializeComponent();
        }

        public void SetListModes(List<DisplayMode> list)
        {
            listBox1.DataSource = list;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _options = new StartOptions();
            _options.Mode = (DisplayMode) 
                    listBox1.SelectedItem;
            _options.IsFullscreen = checkBox1.Checked;
        }
    }
}
