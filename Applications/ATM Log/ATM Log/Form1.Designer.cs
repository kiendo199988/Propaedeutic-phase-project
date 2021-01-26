namespace ATM_Log
{
    partial class Form1
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
            this.readerLb = new System.Windows.Forms.Label();
            this.ReaderBtn = new System.Windows.Forms.Button();
            this.lblReader = new System.Windows.Forms.ListBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.showLatestFileBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.updateMoneyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // readerLb
            // 
            this.readerLb.AutoSize = true;
            this.readerLb.Location = new System.Drawing.Point(336, 68);
            this.readerLb.Name = "readerLb";
            this.readerLb.Size = new System.Drawing.Size(55, 17);
            this.readerLb.TabIndex = 0;
            this.readerLb.Tag = "";
            this.readerLb.Text = "Reader";
            // 
            // ReaderBtn
            // 
            this.ReaderBtn.BackColor = System.Drawing.SystemColors.Info;
            this.ReaderBtn.Location = new System.Drawing.Point(223, 32);
            this.ReaderBtn.Name = "ReaderBtn";
            this.ReaderBtn.Size = new System.Drawing.Size(176, 42);
            this.ReaderBtn.TabIndex = 8;
            this.ReaderBtn.Text = "Read from file manually";
            this.ReaderBtn.UseVisualStyleBackColor = false;
            this.ReaderBtn.Click += new System.EventHandler(this.ReaderBtn_Click);
            // 
            // lblReader
            // 
            this.lblReader.FormattingEnabled = true;
            this.lblReader.ItemHeight = 16;
            this.lblReader.Location = new System.Drawing.Point(339, 100);
            this.lblReader.Name = "lblReader";
            this.lblReader.Size = new System.Drawing.Size(425, 180);
            this.lblReader.TabIndex = 9;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "*.txt";
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            // 
            // showLatestFileBtn
            // 
            this.showLatestFileBtn.Location = new System.Drawing.Point(184, 100);
            this.showLatestFileBtn.Name = "showLatestFileBtn";
            this.showLatestFileBtn.Size = new System.Drawing.Size(137, 42);
            this.showLatestFileBtn.TabIndex = 16;
            this.showLatestFileBtn.Text = "Show Latest File";
            this.showLatestFileBtn.UseVisualStyleBackColor = true;
            this.showLatestFileBtn.Click += new System.EventHandler(this.showLatestFileBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.updateMoneyBtn);
            this.panel2.Controls.Add(this.ReaderBtn);
            this.panel2.Location = new System.Drawing.Point(339, 298);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 100);
            this.panel2.TabIndex = 18;
            // 
            // updateMoneyBtn
            // 
            this.updateMoneyBtn.BackColor = System.Drawing.SystemColors.Info;
            this.updateMoneyBtn.Location = new System.Drawing.Point(12, 32);
            this.updateMoneyBtn.Name = "updateMoneyBtn";
            this.updateMoneyBtn.Size = new System.Drawing.Size(189, 41);
            this.updateMoneyBtn.TabIndex = 15;
            this.updateMoneyBtn.Text = "Update";
            this.updateMoneyBtn.UseVisualStyleBackColor = false;
            this.updateMoneyBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1058, 463);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.showLatestFileBtn);
            this.Controls.Add(this.lblReader);
            this.Controls.Add(this.readerLb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label readerLb;
        private System.Windows.Forms.Button ReaderBtn;
        private System.Windows.Forms.ListBox lblReader;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button showLatestFileBtn;
        private System.Windows.Forms.Button updateMoneyBtn;
    }
}

