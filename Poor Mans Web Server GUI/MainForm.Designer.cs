namespace Poor_Mans_Web_Server_GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.editButton = new System.Windows.Forms.Button();
            this.hostLocalButton = new System.Windows.Forms.Button();
            this.stopLocalButton = new System.Windows.Forms.Button();
            this.chooseDirectoryButton = new System.Windows.Forms.Button();
            this.directoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.changePortButton = new System.Windows.Forms.Button();
            this.consoleTextBox = new System.Windows.Forms.RichTextBox();
            this.phpButton = new System.Windows.Forms.Button();
            this.phpExeFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ftpButton = new System.Windows.Forms.Button();
            this.defaultPageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(14, 470);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit Files";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // hostLocalButton
            // 
            this.hostLocalButton.Location = new System.Drawing.Point(104, 470);
            this.hostLocalButton.Name = "hostLocalButton";
            this.hostLocalButton.Size = new System.Drawing.Size(75, 23);
            this.hostLocalButton.TabIndex = 2;
            this.hostLocalButton.Text = "Host Locally";
            this.hostLocalButton.UseVisualStyleBackColor = true;
            this.hostLocalButton.Click += new System.EventHandler(this.localButton_Click);
            // 
            // stopLocalButton
            // 
            this.stopLocalButton.Location = new System.Drawing.Point(194, 470);
            this.stopLocalButton.Name = "stopLocalButton";
            this.stopLocalButton.Size = new System.Drawing.Size(127, 23);
            this.stopLocalButton.TabIndex = 3;
            this.stopLocalButton.Text = "Stop Hosting Locally";
            this.stopLocalButton.UseVisualStyleBackColor = true;
            this.stopLocalButton.Click += new System.EventHandler(this.stopLocalButton_Click);
            // 
            // chooseDirectoryButton
            // 
            this.chooseDirectoryButton.Location = new System.Drawing.Point(336, 470);
            this.chooseDirectoryButton.Name = "chooseDirectoryButton";
            this.chooseDirectoryButton.Size = new System.Drawing.Size(130, 23);
            this.chooseDirectoryButton.TabIndex = 4;
            this.chooseDirectoryButton.Text = "Choose Local Directory";
            this.chooseDirectoryButton.UseVisualStyleBackColor = true;
            this.chooseDirectoryButton.Click += new System.EventHandler(this.chooseDirectoryButton_Click);
            // 
            // changePortButton
            // 
            this.changePortButton.Location = new System.Drawing.Point(481, 470);
            this.changePortButton.Name = "changePortButton";
            this.changePortButton.Size = new System.Drawing.Size(87, 23);
            this.changePortButton.TabIndex = 5;
            this.changePortButton.Text = "Change Port";
            this.changePortButton.UseVisualStyleBackColor = true;
            this.changePortButton.Click += new System.EventHandler(this.changePortButton_Click);
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Location = new System.Drawing.Point(13, 25);
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.Size = new System.Drawing.Size(934, 413);
            this.consoleTextBox.TabIndex = 6;
            this.consoleTextBox.TabStop = false;
            this.consoleTextBox.Text = "";
            this.consoleTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.consoleTextBox_LinkClicked);
            // 
            // phpButton
            // 
            this.phpButton.Location = new System.Drawing.Point(583, 470);
            this.phpButton.Name = "phpButton";
            this.phpButton.Size = new System.Drawing.Size(91, 23);
            this.phpButton.TabIndex = 7;
            this.phpButton.Text = "Find php.exe";
            this.phpButton.UseVisualStyleBackColor = true;
            this.phpButton.Click += new System.EventHandler(this.phpButton_Click);
            // 
            // ftpButton
            // 
            this.ftpButton.Location = new System.Drawing.Point(689, 470);
            this.ftpButton.Name = "ftpButton";
            this.ftpButton.Size = new System.Drawing.Size(116, 23);
            this.ftpButton.TabIndex = 8;
            this.ftpButton.Text = "Upload File Via FTP";
            this.ftpButton.UseVisualStyleBackColor = true;
            this.ftpButton.Click += new System.EventHandler(this.ftpButton_Click);
            // 
            // defaultPageButton
            // 
            this.defaultPageButton.Location = new System.Drawing.Point(820, 470);
            this.defaultPageButton.Name = "defaultPageButton";
            this.defaultPageButton.Size = new System.Drawing.Size(125, 23);
            this.defaultPageButton.TabIndex = 9;
            this.defaultPageButton.Text = "Choose Default Page";
            this.defaultPageButton.UseVisualStyleBackColor = true;
            this.defaultPageButton.Click += new System.EventHandler(this.defaultPageButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 505);
            this.Controls.Add(this.defaultPageButton);
            this.Controls.Add(this.ftpButton);
            this.Controls.Add(this.phpButton);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.changePortButton);
            this.Controls.Add(this.chooseDirectoryButton);
            this.Controls.Add(this.stopLocalButton);
            this.Controls.Add(this.hostLocalButton);
            this.Controls.Add(this.editButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Silamoth\'s Web Testing Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button hostLocalButton;
        private System.Windows.Forms.Button stopLocalButton;
        private System.Windows.Forms.Button chooseDirectoryButton;
        private System.Windows.Forms.FolderBrowserDialog directoryDialog;
        private System.Windows.Forms.Button changePortButton;
        private System.Windows.Forms.RichTextBox consoleTextBox;
        private System.Windows.Forms.Button phpButton;
        private System.Windows.Forms.OpenFileDialog phpExeFileDialog;
        private System.Windows.Forms.Button ftpButton;
        private System.Windows.Forms.Button defaultPageButton;
    }
}

