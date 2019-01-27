using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Poor_Mans_Web_Server_GUI
{
    public partial class FTPDialog : Form
    {
        public FTPDialog()
        {
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    String host = hostTextBox.Text;
                    client.Credentials = new NetworkCredential(userNameTextBox.Text, passwordTextBox.Text);

                    String folder = folderTextBox.Text;
                    if (folder != String.Empty)
                        folder = "/" + folder;

                    DirectoryInfo info = new DirectoryInfo(Program.directory);

                    FileInfo[] files = info.GetFiles();

                    DirectoryInfo[] directories = info.GetDirectories();

                    foreach (FileInfo fileInfo in files)
                    {
                        client.UploadFile(hostTextBox.Text + folder + "/" + fileInfo.Name, "STOR", Program.directory + "/" + fileInfo.Name);
                    }

                    foreach (DirectoryInfo directoryInfo in directories)
                    {
                        FileInfo[] directoryFiles = directoryInfo.GetFiles();

                        foreach (FileInfo fileInfo in directoryFiles)
                        {
                            client.UploadFile(hostTextBox.Text + folder + "/" + directoryInfo.Name + "/" + fileInfo.Name, "STOR", Program.directory + "/" + directoryInfo.Name + "/" + fileInfo.Name);
                        }                        
                    }

                    //client.UploadFile(hostTextBox.Text + "/public_html/test/index.php", "STOR", Program.directory + "/index.php");  //Example...

                    MessageBox.Show("Directory uploaded...", "Success", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FTPHelp helpDialog = new FTPHelp();
            helpDialog.ShowDialog();
        }
    }
}