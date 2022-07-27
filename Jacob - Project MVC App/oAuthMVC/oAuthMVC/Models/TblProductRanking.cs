using System;
using System.Collections.Generic;

namespace RetroStoreAPI.Models
{
    public partial class TblProductRanking
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int? ProductRanking { get; set; }

        public virtual TblProductInfo ProductNameNavigation { get; set; } = null!;
    }
}
