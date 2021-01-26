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
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;

namespace Food_and_Drink_App
{
    public partial class Form1 : Form
    {
        //qr code
        FilterInfoCollection fic;
        VideoCaptureDevice device;
        List<Result> results;
        Result result;
        string visitorId;

        //database connection
        DataHelper dh;
        private List<int> productIds;
        private List<int> quantities;
        
        //total prize of an order
        private decimal totalPrice;

        //food
        private Product hamburger;
        private Product pizza;
        private Product iceCream;
        private Product chocolate;
        private Product kapsalon;
        private Product donut;
        private Product cookie;
        private Product apple;
        //drink
        private Product coca;
        private Product fanta;
        private Product sprite;
        private Product orangeJuice;
        private Product water;
        private Product whiskey;
        private Product beer;
        private Product mojito;

        //price
        private decimal hamburgerPrice;
        private decimal pizzaPrice;
        private decimal iceCreamPrice;
        private decimal chocolatePrice;
        private decimal kapsalonPrice;
        private decimal donutPrice;
        private decimal cookiePrice;
        private decimal applePrice;
        private decimal cocaPrice;
        private decimal fantaPrice;
        private decimal spritePrice;
        private decimal orangeJuicePrice;
        private decimal waterPrice;
        private decimal whiskeyPrice;
        private decimal beerPrice;
        private decimal mojitoPrice;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Food and drinks";
            DataHelper dh = new DataHelper();
            //btn
            payBtn.Enabled = false;
            receiptBtn.Enabled = false;
            removeBtn.Enabled = false;

            hamburger = dh.GetProduct(1);
            pizza = dh.GetProduct(2);
            chocolate = dh.GetProduct(3);
            iceCream = dh.GetProduct(4);
            kapsalon = dh.GetProduct(5);
            donut = dh.GetProduct(6);
            cookie = dh.GetProduct(7);
            apple = dh.GetProduct(8);
            coca = dh.GetProduct(9);
            fanta = dh.GetProduct(10);
            sprite = dh.GetProduct(11);
            orangeJuice = dh.GetProduct(12);
            water = dh.GetProduct(13);
            whiskey = dh.GetProduct(14);
            beer = dh.GetProduct(15);
            mojito = dh.GetProduct(16);

            lblHamburger.Text = hamburger.Name+" - "+hamburger.Price+ "€";
            lblPizza.Text = pizza.Name + " - " + pizza.Price + "€";
            lblChocolate.Text = chocolate.Name + " - " + chocolate.Price + "€";
            lblIceCream.Text = iceCream.Name + " - " + iceCream.Price + "€";
            lblKapsalon.Text = kapsalon.Name + " - " + kapsalon.Price + "€";
            lblDonut.Text = donut.Name + " - " + donut.Price + "€";
            lblCookie.Text = cookie.Name + " - " + cookie.Price + "€";
            lblApple.Text = apple.Name + " - " + apple.Price + "€";
            lblCoca.Text = coca.Name + " - " + coca.Price + "€";
            lblFanta.Text = fanta.Name + " - " + fanta.Price + "€";
            lblSprite.Text = sprite.Name + " - " + sprite.Price + "€";
            lblOrangeJuice.Text = orangeJuice.Name + " - " + orangeJuice.Price + "€";
            lblWater.Text = water.Name + " - " + water.Price + "€";
            lblWhiskey.Text = whiskey.Name + " - " + whiskey.Price + "€";
            lblBeer.Text = beer.Name + " - " + beer.Price + "€";
            lblMojito.Text = mojito.Name + " - " + mojito.Price + "€";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            dh = new DataHelper();
            totalPrice = 0;
            productIds = new List<int>();
            quantities = new List<int>();
            //hamburger
            if (Convert.ToInt32(numericUpDownHamburger.Value) > 0)
            {
                hamburgerPrice = Convert.ToDecimal(numericUpDownHamburger.Value) * hamburger.Price;

                listBox1.Items.Add(hamburger.Name+ " x" + numericUpDownHamburger.Value 
                + " = " + hamburgerPrice +" euros");
                totalPrice += hamburgerPrice;
                productIds.Add(hamburger.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownHamburger.Value));
            }
            //pizza
            if (Convert.ToInt32(numericUpDownPizza.Value) > 0)
            {
                pizzaPrice = Convert.ToDecimal(numericUpDownPizza.Value) * pizza.Price;
                listBox1.Items.Add(pizza.Name + " x" + numericUpDownPizza.Value
                + " = " + pizzaPrice + " euros");
                totalPrice += pizzaPrice;
                productIds.Add(pizza.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownPizza.Value));
            }
            //chocolate
            if (Convert.ToInt32(numericUpDownChocolate.Value) > 0)
            {
                chocolatePrice = Convert.ToDecimal(numericUpDownChocolate.Value) * chocolate.Price;
                listBox1.Items.Add(chocolate.Name + " x" + numericUpDownChocolate.Value
                + " = " + chocolatePrice + " euros");
                totalPrice += chocolatePrice;
                productIds.Add(chocolate.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownChocolate.Value));
            }
            //ice cream
            if (Convert.ToInt32(numericUpDownIceCream.Value) > 0)
            {
                iceCreamPrice = Convert.ToDecimal(numericUpDownIceCream.Value) * iceCream.Price;
                listBox1.Items.Add(iceCream.Name + " x" + numericUpDownIceCream.Value
                + " = " + iceCreamPrice + " euros");
                totalPrice += iceCreamPrice;
                productIds.Add(iceCream.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownIceCream.Value));
            }
            //kapsalon
            if (Convert.ToInt32(numericUpDownKapsalon.Value) > 0)
            {
                kapsalonPrice = Convert.ToDecimal(numericUpDownKapsalon.Value) * kapsalon.Price;
                listBox1.Items.Add(kapsalon.Name + " x" + numericUpDownKapsalon.Value
                + " = " + kapsalonPrice + " euros");
                totalPrice += kapsalonPrice;
                productIds.Add(kapsalon.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownKapsalon.Value));
            }
            //donut
            if (Convert.ToInt32(numericUpDownDonut.Value) > 0)
            {
                donutPrice = Convert.ToDecimal(numericUpDownDonut.Value) * donut.Price;
                listBox1.Items.Add(donut.Name + " x" + numericUpDownDonut.Value
                + " = " + donutPrice + " euros");
                totalPrice += donutPrice;
                productIds.Add(donut.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownDonut.Value));
            }
            //cookie
            if (Convert.ToInt32(numericUpDownCookie.Value) > 0)
            {
                cookiePrice = Convert.ToDecimal(numericUpDownCookie.Value) * cookie.Price;
                listBox1.Items.Add(cookie.Name + " x" + numericUpDownCookie.Value
                + " = " + cookiePrice + " euros");
                totalPrice += cookiePrice;
                productIds.Add(cookie.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownCookie.Value));
            }
            //apple
            if (Convert.ToInt32(numericUpDownApple.Value) > 0)
            {
                applePrice = Convert.ToDecimal(numericUpDownApple.Value) * apple.Price;
                listBox1.Items.Add(apple.Name + " x" + numericUpDownApple.Value
                + " = " + applePrice + " euros");
                totalPrice += applePrice;
                productIds.Add(apple.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownApple.Value));
            }
            //coca
            if (Convert.ToInt32(numericUpDownCoca.Value) > 0)
            {
                cocaPrice = Convert.ToDecimal(numericUpDownCoca.Value) * coca.Price;
                listBox1.Items.Add(coca.Name + " x" + numericUpDownCoca.Value
                + " = " + cocaPrice + " euros");
                totalPrice += cocaPrice;
                productIds.Add(coca.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownCoca.Value));
            }
            //fanta
            if (Convert.ToInt32(numericUpDownFanta.Value) > 0)
            {
                fantaPrice = Convert.ToDecimal(numericUpDownFanta.Value) * fanta.Price;
                listBox1.Items.Add(fanta.Name + " x" + numericUpDownFanta.Value
                + " = " + fantaPrice + " euros");
                totalPrice += fantaPrice;
                productIds.Add(fanta.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownFanta.Value));
            }
            //orange juice
            if (Convert.ToInt32(numericUpDownOrangeJuice.Value) > 0)
            {
                orangeJuicePrice = Convert.ToDecimal(numericUpDownOrangeJuice.Value) * orangeJuice.Price;
                listBox1.Items.Add(orangeJuice.Name + " x" + numericUpDownOrangeJuice.Value
                + " = " + orangeJuicePrice + " euros");
                totalPrice += orangeJuicePrice;
                productIds.Add(orangeJuice.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownOrangeJuice.Value));
            }
            //sprite
            if (Convert.ToInt32(numericUpDownSprite.Value) > 0)
            {
                spritePrice = Convert.ToDecimal(numericUpDownSprite.Value) * sprite.Price;
                listBox1.Items.Add(sprite.Name + " x" + numericUpDownSprite.Value
                + " = " + spritePrice + " euros");
                totalPrice += spritePrice;
                productIds.Add(sprite.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownSprite.Value));
            }
            //water
            if (Convert.ToInt32(numericUpDownWater.Value) > 0)
            {
                waterPrice = Convert.ToDecimal(numericUpDownWater.Value) * water.Price;
                listBox1.Items.Add(water.Name + " x" + numericUpDownWater.Value
                + " = " + waterPrice + " euros");
                totalPrice += waterPrice;
                productIds.Add(water.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownWater.Value));
            }
            //whiskey
            if (Convert.ToInt32(numericUpDownWhiskey.Value) > 0)
            {
                whiskeyPrice = Convert.ToDecimal(numericUpDownWhiskey.Value) * whiskey.Price;
                listBox1.Items.Add(whiskey.Name + " x" + numericUpDownWhiskey.Value
                + " = " + whiskeyPrice + " euros");
                totalPrice += whiskeyPrice;
                productIds.Add(whiskey.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownWhiskey.Value));
            }
            //beer
            if (Convert.ToInt32(numericUpDownBeer.Value) > 0)
            {
                beerPrice = Convert.ToDecimal(numericUpDownBeer.Value) * beer.Price;
                listBox1.Items.Add(beer.Name + " x" + numericUpDownBeer.Value
                + " = " + beerPrice + " euros");
                totalPrice += beerPrice;
                productIds.Add(beer.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownBeer.Value));
            }
            //mojito
            if (Convert.ToInt32(numericUpDownMojito.Value) > 0)
            {
                mojitoPrice = Convert.ToDecimal(numericUpDownMojito.Value) * mojito.Price;
                listBox1.Items.Add(mojito.Name + " x" + numericUpDownMojito.Value
                + " = " + mojitoPrice + " euros");
                totalPrice += mojitoPrice;
                productIds.Add(mojito.ProductID);
                quantities.Add(Convert.ToInt32(numericUpDownMojito.Value));
            }
            
            //show total prize
            listBox1.Items.Add("Total: " + totalPrice.ToString() + "€");
            numericUpDownBeer.Value = 0;
            numericUpDownChocolate.Value = 0;
            numericUpDownCoca.Value = 0;
            numericUpDownCookie.Value = 0;
            numericUpDownDonut.Value = 0;
            numericUpDownFanta.Value = 0;
            numericUpDownHamburger.Value = 0;
            numericUpDownIceCream.Value = 0;
            numericUpDownKapsalon.Value = 0;
            numericUpDownMojito.Value = 0;
            numericUpDownOrangeJuice.Value = 0;
            numericUpDownPizza.Value = 0;
            numericUpDownSprite.Value = 0;
            numericUpDownWater.Value = 0;
            numericUpDownApple.Value = 0;
            numericUpDownWhiskey.Value = 0;
            payBtn.Enabled = true;

            //btn
            if (totalPrice == 0)
            {
                MessageBox.Show("Please add your products!");
                payBtn.Enabled = false;
                listBox1.Items.Clear();
            }
            else
            {
                confirmBtn.Enabled = false;
                removeBtn.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();

            //details of receipt
            string receipt = "";
            DateTime now = DateTime.Now;
            receipt = now.ToString() + "\n";
            foreach(var item in listBox1.Items)
            {
                receipt += item.ToString() + "\n";
            }
            //clear listbox
            listBox1.Items.Clear();

            //create folder Receipt
            string folderName = @"c:\Receipt";
            string pathString = System.IO.Path.Combine(folderName);
            System.IO.Directory.CreateDirectory(pathString);
            //count nr of text file in Receipt folder
            int receiptCount = Directory.GetFiles(pathString, "*.txt", SearchOption.TopDirectoryOnly).Length;

            //receipt txt file name
            string fileName = "Receipt-" + (receiptCount + 1) + ".txt";
            saveFileDialog1.FileName = fileName;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    sw.WriteLine(receipt);

                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                    receiptBtn.Enabled = false;
                    confirmBtn.Enabled = true;
                    removeBtn.Enabled = false;
                }
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            productIds.Clear();
            quantities.Clear();
            confirmBtn.Enabled = true;
            removeBtn.Enabled = false;
            payBtn.Enabled = false;
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbQRCode.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void payBtn_Click(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
            if (!device.IsRunning)
            {
                device.NewFrame += Device_NewFrame;
                device.Start();
                timer1.Start();
                //scanBtn.Visible = true;
                payBtn.Enabled = false;
                removeBtn.Enabled = false;
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


                    if (result != null)
                    {
                        dh = new DataHelper();
                        decimal balance = 0;
                        int visitorId2 = 0;
                        int age = 0;

                        visitorId = result.ToString();
                        balance = dh.GetVisitorBalance(Convert.ToInt32(visitorId));
                        visitorId2 = Convert.ToInt32(visitorId);
                        age = dh.GetVisitorAge(visitorId2);

                        //if (age < 18)
                        //{
                        //    foreach (int id in productIds)
                        //    {
                        //        if (id == whiskey.ProductID || id == mojito.ProductID || id == beer.ProductID)
                        //        {
                        //                MessageBox.Show("age restriction");       
                        //        }
                        //    }
                        //}
                        if (age >= 18)
                        {
                            if (balance >= totalPrice)
                            {
                                timer1.Stop();
                                if (device.IsRunning)
                                {
                                    device.Stop();
                                }
                                dh.DecreaseVisitorBalance(visitorId2, totalPrice);
                                dh.decreaseProductQuantity(productIds, quantities);
                                dh.IncreaseNrOfSoldItems(productIds, quantities);
                                dh.UpdateProfit();
                                productIds.Clear();
                                quantities.Clear();
                                MessageBox.Show("Successfully purchased!");
                                //listBox1.Items.Clear();
                                receiptBtn.Enabled = true;
                                removeBtn.Enabled = false;
                                payBtn.Enabled = false;
                                pbQRCode.Image = null;



                            }
                            else
                            {
                                productIds.Clear();
                                quantities.Clear();
                                timer1.Stop();
                                if (device.IsRunning)
                                {
                                    device.Stop();
                                }
                                MessageBox.Show("Not enough money in your account!");
                                listBox1.Items.Clear();
                                payBtn.Enabled = false;

                                removeBtn.Enabled = false;
                                confirmBtn.Enabled = true;
                                pbQRCode.Image = null;
                            }
                        }
                        else
                        {
                            if (productIds.Exists(id => id == mojito.ProductID || id == beer.ProductID || id == whiskey.ProductID))
                            {
                                productIds.Clear();
                                quantities.Clear();
                                timer1.Stop();
                                if (device.IsRunning)
                                {
                                    device.Stop();
                                }
                                MessageBox.Show("Your order contains age-restricted products such as whiskey, beer or mojito!");
                                listBox1.Items.Clear();
                                removeBtn.Enabled = false;
                                confirmBtn.Enabled = true;
                            }
                            else
                            {
                                if (balance >= totalPrice)
                                {
                                    timer1.Stop();
                                    if (device.IsRunning)
                                    {
                                        device.Stop();
                                    }
                                    dh.DecreaseVisitorBalance(visitorId2, totalPrice);
                                    dh.decreaseProductQuantity(productIds, quantities);
                                    dh.IncreaseNrOfSoldItems(productIds, quantities);
                                    dh.UpdateProfit();
                                    productIds.Clear();
                                    quantities.Clear();
                                    MessageBox.Show("Successfully purchased!");
                                    //listBox1.Items.Clear();
                                    receiptBtn.Enabled = true;
                                    payBtn.Enabled = false;
                                    removeBtn.Enabled = false;
                                    pbQRCode.Image = null;



                                }
                                else
                                {
                                    productIds.Clear();
                                    quantities.Clear();
                                    timer1.Stop();
                                    if (device.IsRunning)
                                    {
                                        device.Stop();
                                    }
                                    MessageBox.Show("Not enough money in your account!");
                                    listBox1.Items.Clear();
                                    payBtn.Enabled = false;
                                    removeBtn.Enabled = false;
                                    confirmBtn.Enabled = true;
                                }
                            }
                        }
                    }



                }
            }
            catch (NullReferenceException ex) { MessageBox.Show("QR code is not recognized!"); }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            pbQRCode.Image = null;
            listBox1.Items.Clear();
            receiptBtn.Enabled = false;
            removeBtn.Enabled = false;
            confirmBtn.Enabled = true;
            payBtn.Enabled = false;
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
                MessageBox.Show("Nothing to stop!");
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_2(object sender, EventArgs e)
        {

        }

        private void nextCustBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            removeBtn.Enabled = false;
            receiptBtn.Enabled = false;
            confirmBtn.Enabled = true;
        }
    }
}
