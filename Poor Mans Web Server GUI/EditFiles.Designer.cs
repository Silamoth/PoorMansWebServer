namespace Poor_Mans_Web_Server_GUI
{
    partial class EditFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFiles));
            this.filesDataGridView = new System.Windows.Forms.DataGridView();
            this.entry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directoryButton = new System.Windows.Forms.Button();
            this.directoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.createFileButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filesDataGridView
            // 
            this.filesDataGridView.AllowUserToAddRows = false;
            this.filesDataGridView.AllowUserToDeleteRows = false;
            this.filesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.filesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.entry});
            this.filesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.filesDataGridView.MultiSelect = false;
            this.filesDataGridView.Name = "filesDataGridView";
            this.filesDataGridView.ReadOnly = true;
            this.filesDataGridView.RowHeadersVisible = false;
            this.filesDataGridView.Size = new System.Drawing.Size(625, 400);
            this.filesDataGridView.TabIndex = 0;
            this.filesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.filesDataGridView_CellDoubleClick);
            // 
            // entry
            // 
            this.entry.HeaderText = "File/Folder";
            this.entry.Name = "entry";
            this.entry.ReadOnly = true;
            // 
            // directoryButton
            // 
            this.directoryButton.Location = new System.Drawing.Point(13, 434);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(97, 23);
            this.directoryButton.TabIndex = 1;
            this.directoryButton.Text = "Choose Directory";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // createFileButton
            // 
            this.createFileButton.Location = new System.Drawing.Point(186, 434);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(115, 23);
            this.createFileButton.TabIndex = 2;
            this.createFileButton.Text = "New File";
            this.createFileButton.UseVisualStyleBackColor = true;
            this.createFileButton.Click += new System.EventHandler(this.createFileButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(377, 434);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(110, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete Selected File";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // EditFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 490);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.directoryButton);
            this.Controls.Add(this.filesDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Files";
            this.Load += new System.EventHandler(this.EditFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn entry;
        private System.Windows.Forms.Button directoryButton;
        private System.Windows.Forms.DataGridView filesDataGridView;
        private System.Windows.Forms.FolderBrowserDialog directoryDialog;
        private System.Windows.Forms.Button createFileButton;
        private System.Windows.Forms.Button deleteButton;
    }
}