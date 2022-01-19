using System;
using System.Collections.Generic;

#nullable disable

namespace AliExpress
{
    public partial class AliexpressOrdersProduct
    {
        public int Id { get; set; }
        public string SuppliersOrderId { get; set; }
        public string Url { get; set; }
        public string Specification1 { get; set; }
        public int? Quantity { get; set; }
        public float? UnitPrice { get; set; }
        public float? TotalProductTax { get; set; }
    }
}
