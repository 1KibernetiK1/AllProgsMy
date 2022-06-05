using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryCommand
{
    public class ControlBinder :
        CommandBinder<Control>
    {
        protected override void Bind(ICommand com, Control source)
        {
            source.DataBindings.Add("Enabled", com, "Enabled");
            source.DataBindings.Add("Text", com, "Header");
            source.Click += (o, e) => com.Execute();
        }
    }
}
