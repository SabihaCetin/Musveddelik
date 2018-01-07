using DomainEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public partial class Yorum
    {
        public int YorumID { get; set; }
        public string YorumIcerik { get; set; }
        public Nullable<System.DateTime> EklenmeTarihi { get; set; }
        public string AdSoyad { get; set; }
        public int Begeni { get; set; }

        public virtual Makale Makale { get; set; }
        public virtual Kullanici Kullanici { get; set; }

    }
}
