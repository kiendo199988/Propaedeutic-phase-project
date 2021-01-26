using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//aditional stuff for the scanner
using System.IO;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;
//database
//using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

//using MySql.Data;




namespace loanApp
{
    public partial class Form1 : Form
    {
       
        FilterInfoCollection fic;
        VideoCaptureDevice device;
        private List<int> codes= new List<int>();

        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbQRCode.Image = (Bitmap)eventArgs.Frame.Clone();
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device.IsRunning)
            {
                device.Stop();
            }
        }

        //add to list 
        public void AddCode(int code)
        {
            codes.Add(code);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pbQRCode.Image != null)
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    Result result = barcodeReader.Decode((Bitmap)pbQRCode.Image);
                    if (result != null)
                    {
                            DatabaseConnection db = new DatabaseConnection();
                      
                            this.AddCode(int.Parse(result.Text));
                            
                            lbCodes.Items.Add(db.GetProductNameById(int.Parse(result.Text))+" - "+db.GetPurchaseInfo(int.Parse(result.Text))+ "€");


                        timer1.Stop();
                    }
                }
            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("No QR code found");
            }          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void insert_Click(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();
            //db.InsertD(cbbInsertItems.SelectedItem.ToString(), decimal.Parse(tbPrice.Text));
            //int.Parse(age.Text)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();
            db.GiveD();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);

            if (!device.IsRunning)
            {
                device.NewFrame += Device_NewFrame;
                device.Start();
                timer1.Start();
                btnScanNext.Visible = true;
                btnStartScanning.Enabled = false;
                btnStopDevice.Enabled = true;

            }


        }

        private void btnScanNext_Click(object sender, EventArgs e)
        {
            device.Stop();
            if (!device.IsRunning)
            {
                device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
                device.NewFrame += Device_NewFrame;
                device.Start();
                timer1.Start();
            }             
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (this.codes.Count()>0)
            {
                try
                {
                    if (device.IsRunning)
                    {
                        device.Stop();
                        if (btnStartScanning.Enabled == false)
                        {
                            btnStartScanning.Enabled = true;
                            btnScanNext.Visible = false;
                        }
                    }
                    if (pbQRCode.Image != null)
                    {
                        BarcodeReader barcodeReader = new BarcodeReader();
                        Result result = barcodeReader.Decode((Bitmap)pbQRCode.Image);
                        if (result != null)
                        {
                            this.AddCode(int.Parse(result.Text));
                            //lblName.Text = (result.ToString());
                            lbCodes.Items.Add(result);
                            timer1.Stop();
                        }
                    }
                    if (MessageBox.Show("To pay: " + this.GetTotalPrice() + ". " + "Continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show("Please scan customer ID");

                        device.Stop();
                        if (!device.IsRunning)
                        {
                            device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
                            device.NewFrame += Device_NewFrame;
                            device.Start();
                            timer2.Start();
                        }
                    }
                    // MessageBox.Show("To pay:" + this.GetTotalPrice());  //codes[0]
                }
                catch (NullReferenceException)
                {

                    // throw;
                }
            }
        }

        private decimal GetTotalPrice()
        {
            decimal sum = 0;
            
            for (int i = 0; i < codes.Count(); i++)
            {
                DatabaseConnection db = new DatabaseConnection();
                sum += decimal.Parse(db.GetPurchaseInfo(codes[i]));
            }
            return sum;
        }

        public Form1()
        {
            InitializeComponent();
            DatabaseConnection db =new DatabaseConnection();
           
            lbEarP.Text = db.GetQuantity();
            lbPhoneCharger.Text = db.GetQuantity2();
            lbLaptopCharger.Text = db.GetQuantity3();
            lbSpeaker.Text = db.GetQuantity4();
            lbExternalBattery.Text = db.GetQuantity5();
            
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.AntiqueWhite;
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in fic)
            {
                cbCamera.Items.Add(filterInfo.Name);
            }
            cbCamera.SelectedIndex = 0;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pbQRCode.Image != null)
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    Result result = barcodeReader.Decode((Bitmap)pbQRCode.Image);
                    if (result != null)
                    {
                        DatabaseConnection db = new DatabaseConnection();
                       
                        if (db.GetBalance(int.Parse(result.Text)) > GetTotalPrice())
                        {
                            
                            timer2.Stop();
                            if (device.IsRunning)
                            {
                                device.Stop();
                            }
                            //decrease the balance
                            db.DecreaseBalnce(int.Parse(result.Text), GetTotalPrice());
                            if (this.codes!=null)
                            {
                                for (int i = 0; i < codes.Count(); i++)
                                {
                                    db.Loan(int.Parse(result.Text), codes[i]);
                                }
                            }
                            this.codes.Clear();
                            lbCodes.Items.Clear();
                            btnStopDevice.Enabled = false;
                            MessageBox.Show("Payment done. Thank you!");                         
                        }
                        else
                        {
                            timer2.Stop();
                            if (device.IsRunning)
                            {
                                device.Stop();
                            }
                            MessageBox.Show("You don't have enough funds. Please top up your credit first :)");
                        }
                        if (device.IsRunning)
                        {
                            device.Stop();
                            timer2.Stop();
                        }
                        
                    }
                    
                }
            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("No QR code found");

            }   
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.codes.Clear();
            lbCodes.Items.Clear();
            try
            {
               
                if (device.IsRunning)
                {
                    device.Stop();
                    timer1.Stop();
                    btnStartScanning.Enabled = true;
                    btnScanNext.Visible = false;
                }
            }
            catch (NullReferenceException)
            {

               // throw;
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            
            Import m = new Import();
            if (m.Visible==false)
            {
                m.Visible = true;
            }
           
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Return r = new Return();
            if (r.Visible==false)
            {
                r.Visible=true;
            }
           
        }
    }
}
