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

namespace loanApp
{
    public partial class Return : Form
    {
        FilterInfoCollection fic;
        VideoCaptureDevice device;
        public Return()
        {
            InitializeComponent();
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in fic)
            {
                cbCamera.Items.Add(filterInfo.Name);
            }
            cbCamera.SelectedIndex = 0;
        }

        private void Return_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                if (device.IsRunning)
                {
                    device.Stop();
                    timer2.Stop();
                    timer1.Stop();

                }
            }
            catch (NullReferenceException)
            {

                // throw;
            }

        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pbQRCode.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (InvalidOperationException)
            {

                MessageBox.Show("Another scanner is running. Please close it!");
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbItems.Items.Clear();
            device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);

            if (!device.IsRunning)
            {
                device.NewFrame += Device_NewFrame;
                device.Start();
                timer1.Start();
            }
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
                        string name=db.GetCustomerName(int.Parse(result.Text));
                        lblName.Text = name;
                        timer1.Stop();
                        //if (device.IsRunning)
                        //{
                        //    device.Stop();
                        //    timer1.Stop();
                        //    device.NewFrame -= Device_NewFrame;
                        //}
                        if (db.GetLoanedItems(int.Parse(result.Text))!=null)
                        {
                            for (int i = 0; i < (db.GetLoanedItems(int.Parse(result.Text))).Count(); i++)
                            {

                                int itm=db.GetLoanedItems(int.Parse(result.Text))[i];
                                lbItems.Items.Add(db.GetItemsName(int.Parse(result.Text))[i]+" "+itm.ToString());
                            }
                        }
                    }
                    
                }
               
               
            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("No QR code found");
            }           
        }

        private void brReturn_Click(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
           // device.NewFrame += Device_NewFrame;
            if (!device.IsRunning)
            {
                device.NewFrame += Device_NewFrame;
                device.Start();
                timer2.Start();              
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                device.Stop();
                if (!device.IsRunning)
                {
                    device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
                    device.NewFrame += Device_NewFrame;
                    device.Start();
                    timer2.Start();
                }
            }
            catch (Exception)
            {

                //throw;
            }          
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
                        db.Return(int.Parse(result.Text));
                       
                        lblLastReturned.Text = db.LastPrReturned(int.Parse(result.Text));
                    }
                }     
            }
            catch (NullReferenceException)
            {

                // throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (device.IsRunning)
                {
                    timer2.Stop();
                    timer1.Stop();
                    device.Stop();
                   
                    
                }
            }
            catch (NullReferenceException)
            {

                // throw;
            }
        }

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pbQRCode_Click(object sender, EventArgs e)
        {

        }
    }
}
