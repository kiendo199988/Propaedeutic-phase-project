namespace loanApp
{
    partial class Return
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
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.brReturn = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.lblLastReturned = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbQRCode
            // 
            this.pbQRCode.BackColor = System.Drawing.Color.White;
            this.pbQRCode.Location = new System.Drawing.Point(33, 34);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(334, 174);
            this.pbQRCode.TabIndex = 0;
            this.pbQRCode.TabStop = false;
            this.pbQRCode.Click += new System.EventHandler(this.pbQRCode_Click);
            // 
            // lbItems
            // 
            this.lbItems.BackColor = System.Drawing.Color.White;
            this.lbItems.FormattingEnabled = true;
            this.lbItems.ItemHeight = 17;
            this.lbItems.Location = new System.Drawing.Point(26, 17);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(334, 174);
            this.lbItems.TabIndex = 1;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // brReturn
            // 
            this.brReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.brReturn.Location = new System.Drawing.Point(135, 249);
            this.brReturn.Name = "brReturn";
            this.brReturn.Size = new System.Drawing.Size(139, 31);
            this.brReturn.TabIndex = 2;
            this.brReturn.Text = "RETURN ITEMS";
            this.brReturn.UseVisualStyleBackColor = false;
            this.brReturn.Click += new System.EventHandler(this.brReturn_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(154, 240);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(26, 18);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Customer name:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.cbCamera);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.brReturn);
            this.panel1.Controls.Add(this.pbQRCode);
            this.panel1.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(489, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 381);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "SCAN CUST. ID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblLastReturned);
            this.panel2.Controls.Add(this.lbItems);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(55, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 381);
            this.panel2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(767, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "BACK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbCamera
            // 
            this.cbCamera.BackColor = System.Drawing.Color.SeaShell;
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(33, 17);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(334, 25);
            this.cbCamera.TabIndex = 6;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.cbCamera_SelectedIndexChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button4.Location = new System.Drawing.Point(135, 284);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 31);
            this.button4.TabIndex = 9;
            this.button4.Text = "Stop scan";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblLastReturned
            // 
            this.lblLastReturned.AutoSize = true;
            this.lblLastReturned.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastReturned.ForeColor = System.Drawing.Color.Blue;
            this.lblLastReturned.Location = new System.Drawing.Point(201, 291);
            this.lblLastReturned.Name = "lblLastReturned";
            this.lblLastReturned.Size = new System.Drawing.Size(33, 20);
            this.lblLastReturned.TabIndex = 11;
            this.lblLastReturned.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Last returned product:";
            // 
            // Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(964, 541);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Return";
            this.Text = "Return";
            this.Load += new System.EventHandler(this.Return_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button brReturn;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLastReturned;
    }
}