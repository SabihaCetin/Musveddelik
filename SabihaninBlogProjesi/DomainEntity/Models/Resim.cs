using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.Models
{
    public partial class Resim
    {   [Key]
        public int ResimID { get; set; }
        public string KucukBoyut { get; set; }
        public string OrtaBoyut { get; set; }
        public string BuyukBoyut { get; set; }
        public string Video { get; set; }
        public Nullable<int> MakaleID { get; set; }

        public virtual Makale Makale { get; set; }
    }
}
