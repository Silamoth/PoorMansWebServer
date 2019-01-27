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
    public partial class DefaultPageForm : Form
    {
        String name;

        public DefaultPageForm()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            name = nameTextBox.Text;
            Close();
        }

        public String PageName
        {
            get { return name; }
        }
    }
}
