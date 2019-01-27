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
using System.Threading;

namespace Poor_Mans_Web_Server_GUI
{
    public partial class EditFiles : Form
    {
        String directory;
        public Form form;
        String previousDirectory;

        public EditFiles()
        {
            InitializeComponent();      
        }

        private void directoryButton_Click(object sender, EventArgs e)
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

                directory = directoryDialog.SelectedPath + "/";
                Program.directory = directory;

                Del del = new Del(LoadFiles);
                form.BeginInvoke(del);
            }
            catch (Exception ex) { }
        }

        void LoadFiles()
        {
            filesDataGridView.Rows.Clear();

            filesDataGridView.Rows.Add(new DataGridViewRow());
            filesDataGridView.Rows[0].Cells[0].Value = "Up a directory...";

            DirectoryInfo info = new DirectoryInfo(directory);

            FileInfo[] files = info.GetFiles();

            DirectoryInfo[] directories = info.GetDirectories();

            int index = 1;

            foreach (DirectoryInfo directoryInfo in directories)
            {
                //Console.WriteLine(directoryInfo.Attributes.ToString());

                if (!directoryInfo.Attributes.HasFlag(FileAttributes.System))
                {
                    filesDataGridView.Rows.Add(new DataGridViewRow());
                    filesDataGridView.Rows[index].Cells[0].Value = directoryInfo.FullName;

                    index++;
                }
            }

            foreach (FileInfo fileInfo in files)
            {
                if (fileInfo.Extension == ".txt" || fileInfo.Extension == ".html" || fileInfo.Extension == ".css" || fileInfo.Extension == ".php" || fileInfo.Extension == ".csv")
                {
                    filesDataGridView.Rows.Add(new DataGridViewRow());
                    filesDataGridView.Rows[index].Cells[0].Value = fileInfo.FullName;

                    index++;
                }
            }                        
        }

        delegate void Del();

        private void createFileButton_Click(object sender, EventArgs e)
        {
            Editor editor = new Editor(String.Empty);
            editor.Show();
        }

        private void EditFiles_Load(object sender, EventArgs e)
        {
            previousDirectory = String.Empty;
            directory = Program.directory;

            Del del = new Del(LoadFiles);
            form.BeginInvoke(del);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (filesDataGridView.SelectedCells.Count == 0)
                return;

            if (File.Exists(filesDataGridView.SelectedCells[0].Value.ToString()))
            {
                File.Delete(filesDataGridView.SelectedCells[0].Value.ToString());
                LoadFiles();
            }
        }

        private void filesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                try
                {
                    DirectoryInfo info = new DirectoryInfo(directory);

                    directory = info.Parent.FullName;

                    Del del = new Del(LoadFiles);
                    form.BeginInvoke(del);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred...are you perhaps going too high up?", "Error", MessageBoxButtons.OK);
                }

                return;
            }

            String selection = filesDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (File.Exists(selection))
            {
                Editor editor = new Editor(selection);
                editor.Show();

                StreamReader reader = new StreamReader(selection);

                while (reader.Peek() > -1)
                {
                    editor.AddText(reader.ReadLine());
                }

                reader.Close();
            }
            else
            {
                previousDirectory = directory;
                directory = selection;

                Del del = new Del(LoadFiles);
                form.BeginInvoke(del);
            }
        }
    }
}