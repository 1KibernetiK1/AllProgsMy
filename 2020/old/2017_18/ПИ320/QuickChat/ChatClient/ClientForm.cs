using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatClient.Chat;

namespace ChatClient
{
    public partial class ClientForm 
        : Form, IChatServiceCallback
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        public void SendAnswer(string msg)
        {
           
        }
    }
}
