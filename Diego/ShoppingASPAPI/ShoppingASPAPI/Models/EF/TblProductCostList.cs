using System;
using System.Collections.Generic;

namespace ShoppingASPAPI.Models.EF
{
    public partial class TblProductCostList
    {
        public TblProductCostList()
        {
            TblProductsPurchaseds = new HashSet<TblProductsPurchased>();
        }

        public int? ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }

        public virtual TblProductInfo? Product { get; set; }
        public virtual ICollection<TblProductsPurchased> TblProductsPurchaseds { get; set; }
    }
}
