namespace ATM_log_file_generator
{
    partial class QrForm
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
            this.components = new System.ComponentModel.Container();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.lbxInfo = new System.Windows.Forms.ListBox();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.cameraBtn = new System.Windows.Forms.Button();
            this.textFileGenerateBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.topUpBtn = new System.Windows.Forms.Button();
            this.moneyTb = new System.Windows.Forms.TextBox();
            this.idLbl = new System.Windows.Forms.Label();
            this.moneyLbl = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.Button();
            this.scannedIDLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCamera
            // 
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(605, 15);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(208, 24);
            this.cbCamera.TabIndex = 8;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.cbCamera_SelectedIndexChanged);
            // 
            // lbxInfo
            // 
            this.lbxInfo.FormattingEnabled = true;
            this.lbxInfo.ItemHeight = 16;
            this.lbxInfo.Location = new System.Drawing.Point(12, 15);
            this.lbxInfo.Name = "lbxInfo";
            this.lbxInfo.Size = new System.Drawing.Size(562, 212);
            this.lbxInfo.TabIndex = 7;
            this.lbxInfo.SelectedIndexChanged += new System.EventHandler(this.lbxInfo_SelectedIndexChanged);
            // 
            // pbQRCode
            // 
            this.pbQRCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbQRCode.Location = new System.Drawing.Point(605, 44);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(403, 384);
            this.pbQRCode.TabIndex = 6;
            this.pbQRCode.TabStop = false;
            // 
            // cameraBtn
            // 
            this.cameraBtn.Location = new System.Drawing.Point(819, 12);
            this.cameraBtn.Name = "cameraBtn";
            this.cameraBtn.Size = new System.Drawing.Size(92, 27);
            this.cameraBtn.TabIndex = 9;
            this.cameraBtn.Text = "Start";
            this.cameraBtn.UseVisualStyleBackColor = true;
            this.cameraBtn.Click += new System.EventHandler(this.cameraBtn_Click);
            // 
            // textFileGenerateBtn
            // 
            this.textFileGenerateBtn.Location = new System.Drawing.Point(153, 384);
            this.textFileGenerateBtn.Name = "textFileGenerateBtn";
            this.textFileGenerateBtn.Size = new System.Drawing.Size(266, 44);
            this.textFileGenerateBtn.TabIndex = 10;
            this.textFileGenerateBtn.Text = "Generate Text File";
            this.textFileGenerateBtn.UseVisualStyleBackColor = true;
            this.textFileGenerateBtn.Click += new System.EventHandler(this.textFileGenerateBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // topUpBtn
            // 
            this.topUpBtn.Location = new System.Drawing.Point(288, 269);
            this.topUpBtn.Name = "topUpBtn";
            this.topUpBtn.Size = new System.Drawing.Size(286, 58);
            this.topUpBtn.TabIndex = 11;
            this.topUpBtn.Text = "Top-up";
            this.topUpBtn.UseVisualStyleBackColor = true;
            this.topUpBtn.Click += new System.EventHandler(this.topUpBtn_Click);
            // 
            // moneyTb
            // 
            this.moneyTb.Location = new System.Drawing.Point(80, 305);
            this.moneyTb.Name = "moneyTb";
            this.moneyTb.Size = new System.Drawing.Size(156, 22);
            this.moneyTb.TabIndex = 12;
            this.moneyTb.TextChanged += new System.EventHandler(this.moneyTb_TextChanged);
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(13, 269);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(21, 17);
            this.idLbl.TabIndex = 14;
            this.idLbl.Text = "ID";
            this.idLbl.Click += new System.EventHandler(this.idLbl_Click);
            // 
            // moneyLbl
            // 
            this.moneyLbl.AutoSize = true;
            this.moneyLbl.Location = new System.Drawing.Point(12, 310);
            this.moneyLbl.Name = "moneyLbl";
            this.moneyLbl.Size = new System.Drawing.Size(56, 17);
            this.moneyLbl.TabIndex = 15;
            this.moneyLbl.Text = "Deposit";
            this.moneyLbl.Click += new System.EventHandler(this.moneyLbl_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(917, 12);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(91, 27);
            this.stopBtn.TabIndex = 17;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // scannedIDLbl
            // 
            this.scannedIDLbl.AutoSize = true;
            this.scannedIDLbl.Location = new System.Drawing.Point(77, 269);
            this.scannedIDLbl.Name = "scannedIDLbl";
            this.scannedIDLbl.Size = new System.Drawing.Size(159, 17);
            this.scannedIDLbl.TabIndex = 19;
            this.scannedIDLbl.Text = "Your ID will appear here";
            this.scannedIDLbl.Click += new System.EventHandler(this.scannedIDLbl_Click);
            // 
            // QrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 451);
            this.Controls.Add(this.scannedIDLbl);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.moneyLbl);
            this.Controls.Add(this.idLbl);
            this.Controls.Add(this.moneyTb);
            this.Controls.Add(this.topUpBtn);
            this.Controls.Add(this.textFileGenerateBtn);
            this.Controls.Add(this.cameraBtn);
            this.Controls.Add(this.cbCamera);
            this.Controls.Add(this.lbxInfo);
            this.Controls.Add(this.pbQRCode);
            this.Name = "QrForm";
            this.Text = "QrForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QrForm_FormClosing);
            this.Load += new System.EventHandler(this.QrForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.ListBox lbxInfo;
        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.Button cameraBtn;
        private System.Windows.Forms.Button textFileGenerateBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button topUpBtn;
        private System.Windows.Forms.TextBox moneyTb;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.Label moneyLbl;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Label scannedIDLbl;
    }
}