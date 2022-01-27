using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AliExpress
{
    public partial class AliexpressOrder
    {
        public int Id { get; set; }
        [Display(Name= "Order Date")]
        public string OrderDate { get; set; }
        [Display(Name = "Suppliers Order Id")]
        public string SuppliersOrderId { get; set; }
        [Display(Name = "Total Units In Order")]
        public int? TotalUnitsInOrder { get; set; }
        [Display(Name = "Total Cost Of Products")]
        public float? TotalCostOfProducts { get; set; }
        [Display(Name = "Cost Of Shipping")]
        public float? CostOfShipping { get; set; }
        [Display(Name = "Total Order Tax")]
        public float? TotalOrderTax { get; set; }
        [Display(Name = "Currency")]
        public string Currency { get; set; }
        [Display(Name = "Adjusted Price")]
        public float? AdjustedPrice { get; set; }
        [Display(Name = "Total Amount")]
        public float? TotalAmount { get; set; }
        [Display(Name = "Discount")]
        public float? Discount { get; set; }
        [Display(Name = "NzSupply Order Id")]
        public string NzSupplyOrderId { get; set; }
        [Display(Name = "Receipt Document")]
        public string ReceiptDocument { get; set; }
        [Display(Name = "AliExpress Store Name")]
        public string AliExpressStoreName { get; set; }
        [Display(Name = "Order Cancelled")]
        public string OrderCancelled { get; set; }
    }
}
