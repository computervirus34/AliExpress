using System;
using System.Collections.Generic;

#nullable disable

namespace AliExpress
{
    public partial class TrademeCategory
    {
        public int Id { get; set; }
        public int? CategoryCode { get; set; }
        public string CategoryPath { get; set; }
        public string Name { get; set; }
        public string FullCode { get; set; }
        public string CanBeAuctioned { get; set; }
        public string CanBeClassified { get; set; }
        public string DurationsDays { get; set; }
    }
}
