using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BengaliFoodOnline
{

    public class ShoppingCartViewModel
    {
        public List<cartDetails> CartItems { get; set; }
        public int CartTotal { get; set; }
    }

    public class cartDetails
    {
        public string ProductName;
        public int Qty;
        public int Price;
        public int ProductID;
        public string Currency;
        public int Count;

    }
}