namespace Poor_Mans_Web_Server_GUI
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.editorTextBox = new System.Windows.Forms.RichTextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // editorTextBox
            // 
            this.editorTextBox.AcceptsTab = true;
            this.editorTextBox.Location = new System.Drawing.Point(12, 12);
            this.editorTextBox.Name = "editorTextBox";
            this.editorTextBox.Size = new System.Drawing.Size(1018, 492);
            this.editorTextBox.TabIndex = 0;
            this.editorTextBox.Text = "";
            this.editorTextBox.WordWrap = false;
            this.editorTextBox.SelectionChanged += new System.EventHandler(this.editorTextBox_SelectionChanged);
            this.editorTextBox.TextChanged += new System.EventHandler(this.editorTextBox_TextChanged);
            this.editorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editorTextBox_KeyDown);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 549);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(132, 549);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 2;
            this.saveAsButton.Text = "Save As";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 610);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.editorTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox editorTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.SaveFileDialog saveDialog;
    }
}