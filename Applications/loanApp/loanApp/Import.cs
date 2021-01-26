using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loanApp
{
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void insert_Click(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();
            db.InsertD(cbbInsertItems.SelectedItem.ToString(), decimal.Parse(tbPrice.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //Form1 f = new Form1();
            //f.Visible = true;
        }

        private void Import_Load(object sender, EventArgs e)
        {

        }
    }
}
