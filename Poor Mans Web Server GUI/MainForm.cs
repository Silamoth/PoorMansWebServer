using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Poor_Mans_Web_Server_GUI
{
    public partial class MainForm : Form
    {
        public int port;        

        public MainForm()
        {
            InitializeComponent();

            StreamReader reader = new StreamReader("config.txt");

            Program.directory = reader.ReadLine();
            int.TryParse(reader.ReadLine(), out port);
            Program.phpExeDirectory = reader.ReadLine();
            Program.defaultPage = reader.ReadLine();

            reader.Close();
        }

        private void MainForm_Closing(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        public void InsertInTextBox(String text)
        {
            if (text == String.Empty)
                return;

            consoleTextBox.Text += text + Environment.NewLine;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditFiles editFiles = new EditFiles();
            editFiles.form = this;
            editFiles.Show();            
        }

        private void localButton_Click(object sender, EventArgs e)
        {
            if (!Program.getDoStuff())
            {
                Program.setDoStuff(true);
                consoleTextBox.Text += "Waiting for connections on http:localhost:" + port.ToString() + "..." + Environment.NewLine;
            }
            else
                consoleTextBox.Text += "Server is already running..." + Environment.NewLine;
        }

        private void stopLocalButton_Click(object sender, EventArgs e)
        {
            if (Program.getDoStuff())
            {
                Program.setDoStuff(false);
                consoleTextBox.Text += "Closing connection..." + Environment.NewLine;
            }
            else
                consoleTextBox.Text += "Connection is already closed..." + Environment.NewLine;
        }

        private void chooseDirectoryButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowDirectoryDialog));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        void ShowDirectoryDialog()
        {
            try
            {
                directoryDialog.ShowDialog();

                if (directoryDialog.SelectedPath == String.Empty)
                    return;

                Program.directory = directoryDialog.SelectedPath + "/";

                File.WriteAllText("config.txt", "");

                StreamWriter writer = new StreamWriter("config.txt");

                writer.WriteLine(Program.directory);
                writer.WriteLine(port.ToString());
                writer.WriteLine(Program.phpExeDirectory);
                writer.WriteLine(Program.defaultPage);

                writer.Close();
            }
            catch (Exception ex) { }
        }
        
        private void changePortButton_Click(object sender, EventArgs e)
        {
            PortBox portBox = new PortBox();
            portBox.ShowDialog();

            port = portBox.Port;

            File.WriteAllText("config.txt", "");

            StreamWriter writer = new StreamWriter("config.txt");

            writer.WriteLine(Program.directory);
            writer.WriteLine(port.ToString());
            writer.WriteLine(Program.phpExeDirectory);
            writer.WriteLine(Program.defaultPage);

            writer.Close();
        }

        delegate void Del();

        private void consoleTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            LaunchWebLink(e.LinkText);
        }

        void LaunchWebLink(string url)
        {
            Process.Start(url);
        }

        private void phpButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowPHPFileDialog));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        void ShowPHPFileDialog()
        {
            try
            {
                phpExeFileDialog.ShowDialog();

                if (phpExeFileDialog.FileName == String.Empty)
                    return;

                Program.phpExeDirectory = phpExeFileDialog.FileName;

                File.WriteAllText("config.txt", "");

                StreamWriter writer = new StreamWriter("config.txt");

                writer.WriteLine(Program.directory);
                writer.WriteLine(port.ToString());
                writer.WriteLine(Program.phpExeDirectory);
                writer.WriteLine(Program.defaultPage);

                writer.Close();
            }
            catch (Exception ex) { }
        }

        private void ftpButton_Click(object sender, EventArgs e)
        {
            FTPDialog ftpDialog = new FTPDialog();
            ftpDialog.ShowDialog();      }

        private void defaultPageButton_Click(object sender, EventArgs e)
        {
            DefaultPageForm form = new DefaultPageForm();
            form.ShowDialog();
            Program.defaultPage = form.PageName;

            File.WriteAllText("config.txt", "");

            StreamWriter writer = new StreamWriter("config.txt");

            writer.WriteLine(Program.directory);
            writer.WriteLine(port.ToString());
            writer.WriteLine(Program.phpExeDirectory);
            writer.WriteLine(Program.defaultPage);

            writer.Close();
        }
    }
}