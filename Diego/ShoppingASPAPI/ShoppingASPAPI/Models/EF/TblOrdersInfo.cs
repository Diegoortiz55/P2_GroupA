using System;
using System.Collections.Generic;

namespace ShoppingASPAPI.Models.EF
{
    public partial class TblOrdersInfo
    {
        public TblOrdersInfo()
        {
            TblProductsPurchaseds = new HashSet<TblProductsPurchased>();
        }

        public int OrderNo { get; set; }
        public string OrderName { get; set; } = null!;
        public decimal OrderPrice { get; set; }
        public string PaymentType { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int? PointsEarned { get; set; }

        public virtual TblRegisterInfo OrderNameNavigation { get; set; } = null!;
        public virtual ICollection<TblProductsPurchased> TblProductsPurchaseds { get; set; }
    }
}
