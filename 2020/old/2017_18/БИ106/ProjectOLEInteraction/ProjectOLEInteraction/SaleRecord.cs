using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOLEInteraction
{
    public class SaleRecord
    {
        public string Title;
        public int Price;
        public int Amount;

        public SaleRecord(string title, 
                          int price, 
                          int amount)
        {
            Title = title;
            Price = price;
            Amount = amount;
        }
    }
}
