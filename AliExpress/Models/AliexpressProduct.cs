using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AliExpress
{
    public partial class AliexpressProduct
    {
        public int Id { get; set; }
        [Display(Name = "Url")]
        public string Url { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Specification1")]
        public string Specification1 { get; set; }
        [Display(Name = "Main Image")]
        public string MainImage { get; set; }
        [Display(Name = "Images")]
        public string Images { get; set; }
        [Display(Name = "Sku")]
        public string Sku { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "SpecInformation")]
        public string SpecInformation { get; set; }
    }
}
