using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BengaliFoodOnline.Models
{
    public class PendingOrderViewModel
    {
    //    O.OrderDate,O.OrderId,O.FirstName,O.LastName, O.Phone,
    //FI.FoodItemName,FI.Price,
    //OD.ItemQuantity, O.Address,
    //O.CreatedDate
        public PendingOrderViewModel()
        {
            OrderDetails = new List<PendingOrderDetails>();
        }
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        // public string FoodItemName { get; set; }
        // public int Price { get; set; }
        //public Nullable<int> ItemQuantity { get; set; }
        public string Address { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public List<PendingOrderDetails> OrderDetails { get; set; }

    }

    public class PendingOrderDetails
    {
        public string FoodItemName { get; set; }
        public Nullable<int> ItemQuantity { get; set; }
        public int? Price { get; set; }

    }
}