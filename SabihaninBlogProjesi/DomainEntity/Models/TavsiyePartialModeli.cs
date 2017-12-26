using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.Models
{
  public  class TavsiyePartialModeli 
    {
        public int TavsiyePartialModeliID { get; set; }
        public Kullanici k { get; set; }
        public Makale m { get; set; }

    }
}
