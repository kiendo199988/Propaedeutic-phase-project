namespace loanApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbEarP = new System.Windows.Forms.Label();
            this.lbPhoneCharger = new System.Windows.Forms.Label();
            this.lbLaptopCharger = new System.Windows.Forms.Label();
            this.lbSpeaker = new System.Windows.Forms.Label();
            this.lbExternalBattery = new System.Windows.Forms.Label();
            this.btnStartScanning = new System.Windows.Forms.Button();
            this.btnScanNext = new System.Windows.Forms.Button();
            this.lbCodes = new System.Windows.Forms.ListBox();
            this.btnStopDevice = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(257, 339);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(25, 339);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(158, 177);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(25, 55);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(158, 177);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(257, 55);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(158, 177);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(482, 55);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(158, 177);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ear plugs ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "External battery";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Speaker";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(511, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Laptop charger";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(289, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Phone charger";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.pbQRCode);
            this.panel1.Controls.Add(this.cbCamera);
            this.panel1.Location = new System.Drawing.Point(664, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 461);
            this.panel1.TabIndex = 21;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pbQRCode
            // 
            this.pbQRCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbQRCode.Image = ((System.Drawing.Image)(resources.GetObject("pbQRCode.Image")));
            this.pbQRCode.Location = new System.Drawing.Point(0, 25);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(359, 338);
            this.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQRCode.TabIndex = 36;
            this.pbQRCode.TabStop = false;
            // 
            // cbCamera
            // 
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(0, 0);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(359, 24);
            this.cbCamera.TabIndex = 34;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbEarP
            // 
            this.lbEarP.AutoSize = true;
            this.lbEarP.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEarP.Location = new System.Drawing.Point(84, 235);
            this.lbEarP.Name = "lbEarP";
            this.lbEarP.Size = new System.Drawing.Size(18, 18);
            this.lbEarP.TabIndex = 38;
            this.lbEarP.Text = "0";
            // 
            // lbPhoneCharger
            // 
            this.lbPhoneCharger.AutoSize = true;
            this.lbPhoneCharger.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhoneCharger.Location = new System.Drawing.Point(317, 235);
            this.lbPhoneCharger.Name = "lbPhoneCharger";
            this.lbPhoneCharger.Size = new System.Drawing.Size(18, 18);
            this.lbPhoneCharger.TabIndex = 39;
            this.lbPhoneCharger.Text = "0";
            // 
            // lbLaptopCharger
            // 
            this.lbLaptopCharger.AutoSize = true;
            this.lbLaptopCharger.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLaptopCharger.Location = new System.Drawing.Point(555, 235);
            this.lbLaptopCharger.Name = "lbLaptopCharger";
            this.lbLaptopCharger.Size = new System.Drawing.Size(18, 18);
            this.lbLaptopCharger.TabIndex = 40;
            this.lbLaptopCharger.Text = "0";
            // 
            // lbSpeaker
            // 
            this.lbSpeaker.AutoSize = true;
            this.lbSpeaker.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeaker.Location = new System.Drawing.Point(84, 519);
            this.lbSpeaker.Name = "lbSpeaker";
            this.lbSpeaker.Size = new System.Drawing.Size(18, 18);
            this.lbSpeaker.TabIndex = 41;
            this.lbSpeaker.Text = "0";
            // 
            // lbExternalBattery
            // 
            this.lbExternalBattery.AutoSize = true;
            this.lbExternalBattery.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExternalBattery.Location = new System.Drawing.Point(317, 519);
            this.lbExternalBattery.Name = "lbExternalBattery";
            this.lbExternalBattery.Size = new System.Drawing.Size(18, 18);
            this.lbExternalBattery.TabIndex = 42;
            this.lbExternalBattery.Text = "0";
            // 
            // btnStartScanning
            // 
            this.btnStartScanning.BackColor = System.Drawing.Color.LightGreen;
            this.btnStartScanning.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartScanning.Location = new System.Drawing.Point(482, 339);
            this.btnStartScanning.Name = "btnStartScanning";
            this.btnStartScanning.Size = new System.Drawing.Size(158, 43);
            this.btnStartScanning.TabIndex = 44;
            this.btnStartScanning.Text = "Scan products";
            this.btnStartScanning.UseVisualStyleBackColor = false;
            this.btnStartScanning.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnScanNext
            // 
            this.btnScanNext.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnScanNext.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanNext.Location = new System.Drawing.Point(482, 388);
            this.btnScanNext.Name = "btnScanNext";
            this.btnScanNext.Size = new System.Drawing.Size(158, 43);
            this.btnScanNext.TabIndex = 45;
            this.btnScanNext.Text = "Scan next";
            this.btnScanNext.UseVisualStyleBackColor = false;
            this.btnScanNext.Visible = false;
            this.btnScanNext.Click += new System.EventHandler(this.btnScanNext_Click);
            // 
            // lbCodes
            // 
            this.lbCodes.BackColor = System.Drawing.Color.Linen;
            this.lbCodes.FormattingEnabled = true;
            this.lbCodes.ItemHeight = 16;
            this.lbCodes.Location = new System.Drawing.Point(1038, 62);
            this.lbCodes.Name = "lbCodes";
            this.lbCodes.Size = new System.Drawing.Size(171, 452);
            this.lbCodes.TabIndex = 39;
            // 
            // btnStopDevice
            // 
            this.btnStopDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStopDevice.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopDevice.Location = new System.Drawing.Point(482, 437);
            this.btnStopDevice.Name = "btnStopDevice";
            this.btnStopDevice.Size = new System.Drawing.Size(158, 43);
            this.btnStopDevice.TabIndex = 46;
            this.btnStopDevice.Text = "Pay";
            this.btnStopDevice.UseVisualStyleBackColor = false;
            this.btnStopDevice.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEnd.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Location = new System.Drawing.Point(515, 488);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(99, 28);
            this.btnEnd.TabIndex = 53;
            this.btnEnd.Text = "Stop";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImport.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(46, 382);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(92, 43);
            this.btnImport.TabIndex = 55;
            this.btnImport.Text = "IMPORT";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReturn.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(202, 382);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(92, 43);
            this.btnReturn.TabIndex = 56;
            this.btnReturn.Text = "RETURN";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 576);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStopDevice);
            this.Controls.Add(this.lbCodes);
            this.Controls.Add(this.btnScanNext);
            this.Controls.Add(this.btnStartScanning);
            this.Controls.Add(this.lbExternalBattery);
            this.Controls.Add(this.lbSpeaker);
            this.Controls.Add(this.lbLaptopCharger);
            this.Controls.Add(this.lbPhoneCharger);
            this.Controls.Add(this.lbEarP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.Label lbEarP;
        private System.Windows.Forms.Label lbPhoneCharger;
        private System.Windows.Forms.Label lbLaptopCharger;
        private System.Windows.Forms.Label lbSpeaker;
        private System.Windows.Forms.Label lbExternalBattery;
        private System.Windows.Forms.Button btnStartScanning;
        private System.Windows.Forms.Button btnScanNext;
        private System.Windows.Forms.ListBox lbCodes;
        private System.Windows.Forms.Button btnStopDevice;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnReturn;
    }
}

