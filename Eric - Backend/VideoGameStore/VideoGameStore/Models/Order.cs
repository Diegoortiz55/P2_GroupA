using System;
using System.Collections.Generic;

namespace VideoGameStore.Models
{
    public partial class Order
    {
        public int orderNo { get; set; }
        public int orderName { get; set; }
        public int? orderPrice { get; set; }
        public string? paymentType { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? pointsEarned { get; set; }
    }
}
