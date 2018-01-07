using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.Models
{
    public class Ortak
    {
        public Kullanici k { get; set; }
        public List<Kullanici>klar { get; set; }
        public Makale m { get; set; }
        public List<Makale> mler { get; set; }

        public Resim r { get; set; }
    }
}
