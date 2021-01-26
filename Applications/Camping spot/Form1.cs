using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace Camping_spot
{
    public partial class Form1 : Form
    {
        Result result;
        string visitorId;
        public Form1()
        {
            InitializeComponent();

        }

        Database dh;

        FilterInfoCollection fic;
        VideoCaptureDevice device;


        private void Form1_Load(object sender, EventArgs e)
        {
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in fic)
            {
                cbCamera.Items.Add(filterInfo.Name);
            }
            cbCamera.SelectedIndex = 0;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
            timer1.Start();
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbQRCode.Image = (Bitmap)eventArgs.Frame.Clone();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device.IsRunning)
            {
                device.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pbQRCode.Image != null)
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    result = barcodeReader.Decode((Bitmap)pbQRCode.Image);
                    dh = new Database();
                    if (result != null)
                    {
                        visitorId = result.ToString();
                        lbxInfo.Items.Add(visitorId);
                        timer1.Stop();
                        if (device.IsRunning)
                        {
                            device.Stop();
                        }
                    }
                }
            }
            catch (NullReferenceException ex) { MessageBox.Show("QR code is not recognized!"); }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                dh = new Database();
                dh.CheckIn(Convert.ToInt32(visitorId));
                MessageBox.Show("Successfully checked in!");
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("error");
            }

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                dh = new Database();
                dh.CheckOut(Convert.ToInt32(visitorId));
                MessageBox.Show("Successfully checked out!");
            }

            catch (InvalidCastException ex)
            {
                MessageBox.Show("error");
            }
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {

        }
    }
}




