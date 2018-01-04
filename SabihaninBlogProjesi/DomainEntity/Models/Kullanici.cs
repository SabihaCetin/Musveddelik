using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.Models
{
    public partial class Kullanici : IdentityUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            KayitTarihi = DateTime.Now;
         
        }

        public string AdSoyad { get; set; }
        public string Meslek { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Resim { get; set; }
        
    }
}
