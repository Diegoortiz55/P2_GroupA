using System;
using System.Collections.Generic;

namespace ShoppingASPAPI.Models.EF
{
    public partial class TblRegisterInfo
    {
        public TblRegisterInfo()
        {
            TblCustomerContacts = new HashSet<TblCustomerContact>();
            TblOrdersInfos = new HashSet<TblOrdersInfo>();
        }

        public string UserName { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string StAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? CustomerState { get; set; }
        public int? UserPoints { get; set; }

        public virtual ICollection<TblCustomerContact> TblCustomerContacts { get; set; }
        public virtual ICollection<TblOrdersInfo> TblOrdersInfos { get; set; }
    }
}
