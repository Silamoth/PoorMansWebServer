using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poor_Mans_Web_Server_GUI
{
    public partial class PortBox : Form
    {
        int port;

        public PortBox()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            int.TryParse(portTextBox.Text, out port);
            Close();
        }

        public int Port
        {
            get { return port; }
        }
    }
}
