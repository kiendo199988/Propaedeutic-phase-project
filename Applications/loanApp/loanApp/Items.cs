using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loanApp
{
    class Items
    {
        //private int id;
        //private string name;
        //private float price;
        //private int quantity;
        private List<int> codes;
        //private int code;

        public Items()
        {
            this.codes = new List<int>();
        }

        public void AddCode(int code)
        {
            codes.Add(code);
        }

        //doesn't matter -->>

        //public Items(int id, string name, float price, int quantity)
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.price = price;
        //    this.quantity = quantity;
        //}

        //public float SellItem(int quantity)
        //{
        //    float amountToPay = price * quantity;
        //    this.quantity--;
        //    return amountToPay;
        //}

        //public int GetQuantity()
        //{
        //    return this.quantity;
        //}
        //public float GetPrice()
        //{
        //    return this.price;
        //}

    }
}
