using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_log_file_generator
{
    class Visitor
    {
        int id;
        decimal depositAmount;

        public int Id
        {
            get { return this.id; }
            set { id = value; }
        }
        public decimal DepositAmount
        {
            get { return this.depositAmount; }
            set { depositAmount = value; }
        }
        public Visitor(int id, decimal depositAmount)
        {
            this.id = id;
            this.depositAmount = depositAmount;
        }
    }
}
