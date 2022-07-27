using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace oAuthMVC.Models
{
    public partial class Ranking
    {
        [Display(Name = "Id")]
        public int productId { get; set; }
        [Display(Name = "Name")]
        public string productName { get; set; }
        [Display(Name = "Ranking")]
        [System.ComponentModel.DataAnnotations.Range(1, 10, ErrorMessage = "Game Rankings must be between 1 and 10")]
        public int productRanking { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; } = new HashSet<Ranking>();

        [NotMapped]
        public int OverallRanking
        {
            get
            {
                if (Rankings.Count > 1)
                {
                    return (int)Rankings.Average(x => x.productRanking);
                }
                return (0);
            }
        }

    }
}
