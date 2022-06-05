using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, 
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class ServerForm 
        : Form, IChatService
    {
        private ServiceHost host;

        public ServerForm()
        {
            InitializeComponent();
        }

        public void SendMessage(string msg)
        {
            throw new NotImplementedException();
        }

        public void UserJoin(string name)
        {
            listBox1.Items.Add(name);
        }

        public void UserLeave(string name)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                host = new ServiceHost(this);
                host.Open();
                MessageBox.Show("Сервис запущен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
