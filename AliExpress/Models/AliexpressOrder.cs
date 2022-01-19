using System;
using System.Collections.Generic;

#nullable disable

namespace AliExpress
{
    public partial class AliexpressOrder
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public string SuppliersOrderId { get; set; }
        public int? TotalUnitsInOrder { get; set; }
        public float? TotalCostOfProducts { get; set; }
        public float? CostOfShipping { get; set; }
        public float? TotalOrderTax { get; set; }
        public string Currency { get; set; }
        public float? AdjustedPrice { get; set; }
        public float? TotalAmount { get; set; }
        public float? Discount { get; set; }
        public string NzSupplyOrderId { get; set; }
        public string ReceiptDocument { get; set; }
        public string AliExpressStoreName { get; set; }
        public string OrderCancelled { get; set; }
    }
}
