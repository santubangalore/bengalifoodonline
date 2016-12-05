﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BengaliFoodOnline
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class BengalifoodOnlineDbContext : DbContext
    {
        public BengalifoodOnlineDbContext()
            : base("name=BengalifoodOnlineDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FoodmenuItem> FoodmenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Company> Companies { get; set; }
    
        public virtual ObjectResult<NQS_GetAllFoodmenuItem_Result> NQS_GetAllFoodmenuItem()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NQS_GetAllFoodmenuItem_Result>("NQS_GetAllFoodmenuItem");
        }
    
        public virtual ObjectResult<NQS_GetShoopingCart_Result> NQS_GetShoopingCart(string cartid, Nullable<int> productID)
        {
            var cartidParameter = cartid != null ?
                new ObjectParameter("cartid", cartid) :
                new ObjectParameter("cartid", typeof(string));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NQS_GetShoopingCart_Result>("NQS_GetShoopingCart", cartidParameter, productIDParameter);
        }
    
        public virtual ObjectResult<NQS_GetShoppingCart_Result> NQS_GetShoppingCart(string cartid, Nullable<int> productID)
        {
            var cartidParameter = cartid != null ?
                new ObjectParameter("cartid", cartid) :
                new ObjectParameter("cartid", typeof(string));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NQS_GetShoppingCart_Result>("NQS_GetShoppingCart", cartidParameter, productIDParameter);
        }
    
        public virtual int NQS_InsertShoppingCartItem(Nullable<int> cartorderID, Nullable<System.DateTime> cartDate, string cartUniqID, Nullable<int> cartCustomerID, Nullable<int> productID, Nullable<int> itemQty, Nullable<int> cartAmount, Nullable<int> count)
        {
            var cartorderIDParameter = cartorderID.HasValue ?
                new ObjectParameter("CartorderID", cartorderID) :
                new ObjectParameter("CartorderID", typeof(int));
    
            var cartDateParameter = cartDate.HasValue ?
                new ObjectParameter("CartDate", cartDate) :
                new ObjectParameter("CartDate", typeof(System.DateTime));
    
            var cartUniqIDParameter = cartUniqID != null ?
                new ObjectParameter("CartUniqID", cartUniqID) :
                new ObjectParameter("CartUniqID", typeof(string));
    
            var cartCustomerIDParameter = cartCustomerID.HasValue ?
                new ObjectParameter("CartCustomerID", cartCustomerID) :
                new ObjectParameter("CartCustomerID", typeof(int));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            var itemQtyParameter = itemQty.HasValue ?
                new ObjectParameter("ItemQty", itemQty) :
                new ObjectParameter("ItemQty", typeof(int));
    
            var cartAmountParameter = cartAmount.HasValue ?
                new ObjectParameter("CartAmount", cartAmount) :
                new ObjectParameter("CartAmount", typeof(int));
    
            var countParameter = count.HasValue ?
                new ObjectParameter("Count", count) :
                new ObjectParameter("Count", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("NQS_InsertShoppingCartItem", cartorderIDParameter, cartDateParameter, cartUniqIDParameter, cartCustomerIDParameter, productIDParameter, itemQtyParameter, cartAmountParameter, countParameter);
        }
    
        public virtual ObjectResult<NQS_ShowOrderDetails_Result> NQS_ShowOrderDetails(Nullable<System.DateTime> fromdate, Nullable<System.DateTime> todate, Nullable<int> orderno)
        {
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(System.DateTime));
    
            var ordernoParameter = orderno.HasValue ?
                new ObjectParameter("orderno", orderno) :
                new ObjectParameter("orderno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NQS_ShowOrderDetails_Result>("NQS_ShowOrderDetails", fromdateParameter, todateParameter, ordernoParameter);
        }
    }
}
