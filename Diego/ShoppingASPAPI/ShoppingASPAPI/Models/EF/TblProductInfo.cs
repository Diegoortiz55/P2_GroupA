using System;
using System.Collections.Generic;

namespace ShoppingASPAPI.Models.EF
{
    public partial class TblProductInfo
    {
        public TblProductInfo()
        {
            TblProductCostLists = new HashSet<TblProductCostList>();
            TblProductRankings = new HashSet<TblProductRanking>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public string ProductGenre { get; set; } = null!;
        public string ProductPlatform { get; set; } = null!;
        public string ProductManufacturer { get; set; } = null!;
        public int? ProductReleaseDate { get; set; }
        public decimal? ProductCost { get; set; }
        public int? ProductQty { get; set; }
        public bool? ProductIsInStock { get; set; }

        public virtual ICollection<TblProductCostList> TblProductCostLists { get; set; }
        public virtual ICollection<TblProductRanking> TblProductRankings { get; set; }
    }
}
