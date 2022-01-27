using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AliExpress
{
    public partial class AliexpressOrdersProduct
    {
        public int Id { get; set; }
        [Display(Name = "Suppliers Order Id")]
        public string SuppliersOrderId { get; set; }
        [Display(Name = "Url")]
        public string Url { get; set; }
        [Display(Name = "Specification1")]
        public string Specification1 { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }
        [Display(Name = "UnitPrice")]
        public float? UnitPrice { get; set; }
        [Display(Name = "Total Product Tax")]
        public float? TotalProductTax { get; set; }
    }
}
