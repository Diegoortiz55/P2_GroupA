using System;
using System.Collections.Generic;

namespace ShoppingASPAPI.Models.EF
{
    public partial class TblProductsPurchased
    {
        public int OrderNo { get; set; }
        public string ProductName { get; set; } = null!;
        public int OrderQty { get; set; }

        public virtual TblOrdersInfo OrderNoNavigation { get; set; } = null!;
        public virtual TblProductCostList ProductNameNavigation { get; set; } = null!;
    }
}
