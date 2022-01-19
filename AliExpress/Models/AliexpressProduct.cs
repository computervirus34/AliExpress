using System;
using System.Collections.Generic;

#nullable disable

namespace AliExpress
{
    public partial class AliexpressProduct
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ProductName { get; set; }
        public string Specification1 { get; set; }
        public string MainImage { get; set; }
        public string Images { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string SpecInformation { get; set; }
    }
}
