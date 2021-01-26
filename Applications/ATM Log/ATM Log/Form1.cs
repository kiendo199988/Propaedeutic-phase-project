using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;

namespace ATM_Log
{
    public partial class Form1 : Form
    {
        private delegate void EnableBtnDelegate(object sender, FileSystemEventArgs e);
        DataHelper dh;
        ATMreader ATMreader;
        //public delegate void TopUpBalnceDelegate();

        FileSystemWatcher watcher = new FileSystemWatcher()
        {
            Path = @"c:\copy of ATM Log Files",
            Filter = "*.txt"
        };
        public Form1()
        {
            InitializeComponent();
            this.Text = "ATM Log Updater";
            dh = new DataHelper();
            //updateMoneyBtn.Enabled = false;

            // Add event handlers for all events you want to handle
            watcher.Created += new FileSystemEventHandler(AlertWhenANewFileIsCreated);
            //enable watcher
            watcher.EnableRaisingEvents = true;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void EnableUpdateBtn(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("New file added");
        }
        private void ReaderBtn_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            List<decimal> amounts = new List<decimal>();
            decimal totalDeposit = 0;
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ATMreader = new ATMreader(ofd.FileName);

                if (ATMreader.LoadCustomersFromFile(ref amounts,ref ids))
                {
                    if (dh.AddMoneyToAccount(ids, amounts))
                    {
                        foreach (decimal amount in amounts)
                        {
                            totalDeposit += amount;
                        }
                        dh.UpdateDeposit(totalDeposit);
                        MessageBox.Show("Update balance succesfully!!");
                    }
                    else
                    {
                        MessageBox.Show("Fail to update balance!");
                    }
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            //dh.updateMoney(Convert.ToInt32(idTb.Text), Convert.ToDecimal(moneyTb.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //test
        public void AlertWhenANewFileIsCreated(object sender, EventArgs e)
        {
            MessageBox.Show("A new file is created!");
        }
        


        //Read the latest file created 
        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {

            //string path = @"c:\copy of ATM Log Files";


            //DirectoryInfo directoryInfo = new DirectoryInfo(path);
            //FileInfo[] files = directoryInfo.GetFiles();
            //DateTime recentCreated = DateTime.MinValue;
            //FileInfo recentFile = null;

            //foreach (FileInfo file in files)
            //{
            //    if (file.CreationTime > recentCreated)
            //    {
            //        recentCreated = file.CreationTime;
            //        recentFile = file;
            //    }
            //}
            //get latest file name
            //string path2 = @"c:\copy of ATM Log Files\" + recentFile.Name;
            ////List of IDs
            //List<int> ids = new List<int>();
            ////List of amount of deposits
            //List<decimal> amounts = new List<decimal>();

            //ATMreader = new ATMreader(path2);

            //if (ATMreader.LoadCustomersFromFile(ref amounts, ref ids))
            //{
            //    if (dh.AddMoneyToAccount(ids, amounts))
            //    {
            //        MessageBox.Show("Transaction ok!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Fail!");
            //    }
            //}
            ;
            //MessageBox.Show("abc");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"c:\copy of ATM Log Files";


            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();
            DateTime recentCreated = DateTime.MinValue;
            FileInfo recentFile = null;

            foreach (FileInfo file in files)
            {
                if (file.CreationTime > recentCreated)
                {
                    recentCreated = file.CreationTime;
                    recentFile = file;
                }
            }
            //get latest file name
            string path2 = @"c:\copy of ATM Log Files\" + recentFile.Name;
            //List of IDs
            List<int> ids = new List<int>();
            //List of amount of deposits
            List<decimal> amounts = new List<decimal>();

            ATMreader = new ATMreader(path2);

            if (ATMreader.LoadCustomersFromFile(ref amounts, ref ids))
            {
                if (dh.AddMoneyToAccount(ids, amounts))
                {
                    MessageBox.Show("Update balance succesfully!");
                }
                else
                {
                    MessageBox.Show("Fail!");
                }
            }
            //lblReader.Items.Clear();
            //lblReader.Items.Add("Newest log file added: " + recentFile.Name);
            
        }

        private void updateReaderBtn_Click(object sender, EventArgs e)
        {
        }

        
        private void showLatestFileBtn_Click(object sender, EventArgs e)
        {
            string path = @"c:\copy of ATM Log Files";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();
            DateTime recentCreated = DateTime.MinValue;
            FileInfo recentFile = null;

            foreach (FileInfo file in files)
            {
                if (file.CreationTime > recentCreated)
                {
                    recentCreated = file.CreationTime;
                    recentFile = file;
                }
            }
            lblReader.Items.Clear();
            lblReader.Items.Add(recentFile.Name +" "+ recentFile.CreationTime);
        }
    }
}
