using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWordAuto
{
    public class ProductOrder
    {
        public string Name;
        public int Price;
        public int Quantity;

        public ProductOrder(string name, int price, int quantity)
        {
            Price = price;
            Name = name;
            Quantity = quantity;
        }

        public int Cost
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}
