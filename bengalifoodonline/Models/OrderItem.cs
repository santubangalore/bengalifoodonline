using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BengaliFoodOnline.Models
{
    public class OrderItem
    {
        public int MenuItemID { get; set; }

        public int Quantity { get; set; }

        public DateTime Odate { get; set; }
        
    }
}