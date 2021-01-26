using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ATM_Log
{
    
    class ATMreader
    {
        public string filePath { get; private set; }
        //private List<Customer> myCustomers;
        public ATMreader(string fp)
        {
            filePath = fp;
        }

       
        public bool LoadCustomersFromFile(ref List<decimal> amountList, ref List<int> idList )
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                sr.ReadLine();
                sr.ReadLine();
                int counter = 0;
                int countTransactionNr = Convert.ToInt32(sr.ReadLine());
                while (counter < countTransactionNr)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    int id = int.Parse(line[0], System.Globalization.CultureInfo.InvariantCulture);
                    decimal amount = decimal.Parse(line[1], System.Globalization.CultureInfo.InvariantCulture);
                    idList.Add(id);
                    amountList.Add(amount);
                    counter++;
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error! I/O error");
            }
            finally
            {
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();
            }
            return true;
        }
    }
}
