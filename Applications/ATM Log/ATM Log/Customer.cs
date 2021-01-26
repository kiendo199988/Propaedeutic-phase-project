using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Log
{
    class Customer
    {
        private int id;
        private string email;
        private string password;
        private double deposit;
        private double balance;

        public int Id
        {
            get{ return this.id; }
        }
        public string Email
        {
            get { return this.email; }
        }
        public string Password
        {
            get { return this.password; }
        }
        public double Deposit
        {
            get { return this.deposit; }
        }
        public double Balance
        {
            get { return this.balance; }
        }

        public Customer(int id, string email,string password,double deposit)
        {
            this.balance = 0;
            this.id = id;
            this.email = email;
            this.password = password;
            this.deposit = deposit;
        }
        public override string ToString()
        {
            string s = this.balance + " euros";
            return s;
        }
    }
}
