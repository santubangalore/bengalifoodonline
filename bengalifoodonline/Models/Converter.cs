using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace BengaliFoodOnline.Models
{
    public class Converter
    {
        public static PendingOrderViewModel ConvertDLtoBL(ObjectResult<NQS_ShowOrderDetails_Result>  resultObject)
        {
            PendingOrderViewModel povm = new PendingOrderViewModel();
            try
            {
                foreach (NQS_ShowOrderDetails_Result obj in resultObject)
                {
                    povm.FirstName = obj.FirstName;
                    povm.Address = obj.Address;
                    povm.CreatedDate = obj.CreatedDate;
                    povm.LastName = obj.LastName;
                    povm.OrderDate = obj.OrderDate;

                    PendingOrderDetails pdtl = new PendingOrderDetails();
                    pdtl.FoodItemName = obj.FoodItemName;
                    pdtl.ItemQuantity = obj.ItemQuantity;
                    pdtl.Price = obj.Price;
                    povm.OrderDetails.Add(pdtl);
                }
            }
            catch (Exception exx)
            {
                return null;
            }
            return povm;
        }
    }
}