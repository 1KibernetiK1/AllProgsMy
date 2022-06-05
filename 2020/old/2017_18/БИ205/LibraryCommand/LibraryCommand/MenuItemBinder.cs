using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryCommand
{
    public class MenuItemBinder :
        CommandBinder<ToolStripItem>
    {
        protected override void Bind(ICommand com, 
                                     ToolStripItem source)
        {
            source.Text = com.Header;
            source.Enabled = com.Enabled;
            source.Click += (o, e) => com.Execute();

            com.PropertyChanged += (o, e) =>
                    source.Enabled = com.Enabled;
        }
    }
}
