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
using System.IO;

namespace ATM_log_file_generator
{
    public partial class QrForm : Form
    {
        FilterInfoCollection fic;
        VideoCaptureDevice device;
        List<Result> results;
        Result result;
        Visitor visitor;
        List<Visitor> visitors;


        DateTime now = DateTime.Now;          //private savefiledialog savefiledialog1;
        private double depositAmount;
        List<double> depositAmounts;
        public QrForm()
        {
            InitializeComponent();
            visitors = new List<Visitor>();
            
        }
        
        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QrForm_Load_1(object sender, EventArgs e)
        {
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in fic)
            {
                cbCamera.Items.Add(filterInfo.Name);
            }
            cbCamera.SelectedIndex = 0;
        }

        private void cameraBtn_Click(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
            if (!device.IsRunning)
            {
                device.NewFrame += Device_NewFrame;
                device.Start();
                timer1.Start();
            }
            cameraBtn.Enabled = false;
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbQRCode.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pbQRCode.Image != null)
                {

                    BarcodeReader barcodeReader = new BarcodeReader();
                    result = barcodeReader.Decode((Bitmap)pbQRCode.Image);

                    if (result != null)
                    {
                        timer1.Stop();
                        if (device.IsRunning)
                        {
                            device.Stop();
                        }

                        //lbxInfo.Items.Add(result.ToString());
                        scannedIDLbl.Text = result.ToString();

                        pbQRCode.Image = null;

                    }



                }
            }
            catch(NullReferenceException ex) { MessageBox.Show("QR code is not recognized!"); }
           
           
        }

        private void QrForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(device != null)
            {
                if (device.IsRunning)
                {
                    device.Stop();
                }
            }
            else
            {
                MessageBox.Show("Close the scanner!");
            }
            

        }

        private void textFileGenerateBtn_Click(object sender, EventArgs e)
        {

            string folderName = @"c:\ATM Log Files";
            string pathString = System.IO.Path.Combine(folderName);
            System.IO.Directory.CreateDirectory(pathString);

            string folderName2 = @"c:\copy of ATM Log Files";
            string pathString2 = System.IO.Path.Combine(folderName2);
            System.IO.Directory.CreateDirectory(pathString2);

            int fCount = Directory.GetFiles(pathString, "*.txt", SearchOption.TopDirectoryOnly).Length;

            string fileName = "ATM LOG-" + (fCount + 1)+".txt";

            //if (!System.IO.File.Exists(pathString))
            //{
            //    using (System.IO.FileStream fs = System.IO.File.Create(pathString))
            //    {

            //    }
            //}


            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = fileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                //System.IO.FileStream fs = System.IO.File.Create(pathString);
                StreamWriter sw = null;
                try
                {
                    fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    sw.WriteLine("NL91 ABNA 0417 1643 00");
                    sw.WriteLine(now);
                    sw.WriteLine(visitors.Count());
                    foreach (Visitor v in visitors)
                    {
                        sw.WriteLine(v.Id.ToString() + " " + v.DepositAmount.ToString());

                    }


                }
                catch (IOException)
                {
                    MessageBox.Show("Error! I/O error");
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                    visitors.Clear();
                    lbxInfo.Items.Clear();
                    pbQRCode.Image = null;
                    scannedIDLbl.Text = string.Empty;
                    try
                    {
                        if (device.IsRunning)
                        {
                            device.Stop();
                            pbQRCode.Image = null;

                        }
                        else
                        {
                            pbQRCode.Image = null;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please push the cancel button!");
            }
            string destinationDirectory = "c:\\copy of ATM Log Files\\";

            string fileToCopy = @"c:\ATM Log Files\" + fileName;
            try 
            {
                File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));
            }
            catch
            {

            }
        }

        private void topUpBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                DateTime now = DateTime.Now;
                depositAmount = Convert.ToDouble(moneyTb.Text);
                visitor = new Visitor(Convert.ToInt32(scannedIDLbl.Text), Convert.ToDecimal(moneyTb.Text));
                visitors.Add(visitor);
                moneyTb.Text = string.Empty;
                lbxInfo.Items.Add(now + "\n");
                lbxInfo.Items.Add("ID: "+visitor.Id+" - Deposit amount: "+ visitor.DepositAmount+ "€");
                lbxInfo.Items.Add("");
                lbxInfo.Items.Add("*****************************************");
                lbxInfo.Items.Add("");

                pbQRCode.Image = null;
                scannedIDLbl.Text = "Your ID will appear here!";
                //try
                //{
                //    if (device.IsRunning)
                //    {
                //        device.Stop();
                //        pbQRCode.Image = null;

                //    }
                //    else
                //    {
                //        pbQRCode.Image = null;
                //    }
                //}
                //catch (NullReferenceException)
                //{
                //    MessageBox.Show("error");
                //}

                device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
                if (!device.IsRunning)
                {
                    device.NewFrame += Device_NewFrame;
                    device.Start();
                    timer1.Start();
                }
            }
            catch (System.FormatException )
            {
                MessageBox.Show("Scan your QR code and enter your top-up amount!");
            }
        }

        private void showVisitorListBtn_Click(object sender, EventArgs e)
        {
            lbxInfo.Items.Clear();
            foreach (Visitor v in visitors)
            {
                lbxInfo.Items.Add(v.Id.ToString() + " " + v.DepositAmount.ToString());
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            pbQRCode.Image = null;
            scannedIDLbl.Text = "Your ID will appear here!";
            cameraBtn.Enabled = true;
            try
            {
                if (device.IsRunning)
                {
                    device.Stop();
                    pbQRCode.Image = null;

                }
                else
                {
                    pbQRCode.Image = null;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("error");
            }
        }

        private void scanBtn_Click(object sender, EventArgs e)
        {
            try
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
            catch(NullReferenceException ex) { MessageBox.Show("Start the camera first!"); }
        }

        private void lbxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void moneyLbl_Click(object sender, EventArgs e)
        {

        }

        private void scannedIDLbl_Click(object sender, EventArgs e)
        {

        }

        private void idLbl_Click(object sender, EventArgs e)
        {

        }

        private void moneyTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
