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
            Facebook = "https://www.facebook.com/";
            Twitter= "https://twitter.com/";
            Instagram = "https://www.instagram.com";
            Resim = "kediler.jpg7e6ff.jpg";
            DogumTarihi = DateTime.Now;
            KayitTarihi = DateTime.Now;
            this.Makaleler = new HashSet<Makale>();
        }
        [Required]
        public string AdSoyad { get; set; }
        [Required]

        public string Meslek { get; set; }
        public bool Cinsiyet { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string ArkaPlanResmi { get; set; }
  

        public DateTime? DogumTarihi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Makale> Makaleler { get; set; }

    }
}
