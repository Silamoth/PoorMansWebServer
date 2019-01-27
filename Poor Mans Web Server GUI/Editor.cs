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
using System.Text.RegularExpressions;
using System.Threading;

namespace Poor_Mans_Web_Server_GUI
{
    public partial class Editor : Form
    {
        String filePath;
        String oldText;
        int currentLineNumber;
        String textBoxContents;

        public Editor(String filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
            textBoxContents = String.Empty;
        }

        public void AddText(String text)
        {
            editorTextBox.Text += text + Environment.NewLine;
            oldText += text + Environment.NewLine;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (filePath == String.Empty)
            {
                Thread thread = new Thread(new ThreadStart(SaveAs));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

                return;
            }

            Save();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(SaveAs));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        void SaveAs()
        {
            try
            {
                saveDialog.Filter = "HTML Files (*.html)|*.html|CSS Files (*.css)|*.css|PHP Files (*.php)|*.php|Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv";
                saveDialog.ShowDialog();
                filePath = saveDialog.FileName;

                File.WriteAllText(filePath, "");    //Clear the file

                StreamWriter writer = new StreamWriter(filePath);

                List<String> textArray = new List<String>(Regex.Split(textBoxContents, "\n"));

                for (int i = 0; i < textArray.Count; i++)
                {
                    writer.WriteLine(textArray[i]);
                }

                writer.Close();
            }
            catch (Exception ex) { } 
        }

        void Save()
        {
            File.WriteAllText(filePath, "");    //Clear the file

            StreamWriter writer = new StreamWriter(filePath);

            List<String> textArray = new List<String>(Regex.Split(textBoxContents, "\n"));

            for (int i = 0; i < textArray.Count; i++)
            {
                writer.WriteLine(textArray[i]);
            }

            writer.Close();

            oldText = editorTextBox.Text;

            MessageBox.Show("File saved...", "Result");   //Should change to a better, more subtle visual indication
        }

        private void editorTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return))
                return;

            String previousLine = editorTextBox.Lines[currentLineNumber];

            int tabCount = 0;

            while (previousLine.IndexOf("\t") != -1)
            {
                tabCount++;

                previousLine = previousLine.Remove(previousLine.IndexOf("\t"), "\t".Length);
            }

            String[] lines = new String[editorTextBox.Lines.Length + 1];

            for (int i = 0; i < editorTextBox.Lines.Length; i++)
            {
                lines[i] = editorTextBox.Lines[i];
            }

            char[] prevLineChar = previousLine.TrimEnd().ToCharArray();

            if (prevLineChar.Length > 0)
            {
                if (prevLineChar[prevLineChar.Length - 1] == '{')
                    tabCount++;
                else if (prevLineChar[prevLineChar.Length - 1] == '}')
                {
                    lines[currentLineNumber] = lines[currentLineNumber].Remove(lines[currentLineNumber].IndexOf("\t"), "\t".Length);

                    tabCount--;
                }
            }
            
            String newContents = String.Empty;

            for (int i = 0; i < tabCount; i++)
            {
                newContents += "\t";
            }

            lines[currentLineNumber + 1] = newContents;

            editorTextBox.Lines = lines;          
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (editorTextBox.Text != String.Empty && (oldText == null || oldText.Replace("\r", "") != editorTextBox.Text))
            {
                if (MessageBox.Show("This document is unsaved.  Would you like to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save();
                }
            }
        }

        private void editorTextBox_SelectionChanged(object sender, EventArgs e)
        {
            currentLineNumber = editorTextBox.GetLineFromCharIndex(editorTextBox.SelectionStart);
        }

        private void editorTextBox_TextChanged(object sender, EventArgs e)
        {
            textBoxContents = editorTextBox.Text;

            if (editorTextBox.Lines.Length > 0 && editorTextBox.Lines[0] == String.Empty)
            {
                List<String> lines = new List<String>();

                for (int i = 1; i < editorTextBox.Lines.Length; i++)
                {
                    lines.Add(editorTextBox.Lines[i]);
                }

                editorTextBox.Lines = lines.ToArray();
                editorTextBox.SelectionStart = Math.Max(0, editorTextBox.TextLength);
            }
        }
    }
}