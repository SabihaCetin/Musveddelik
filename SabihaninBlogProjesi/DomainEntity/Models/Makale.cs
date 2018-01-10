using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.Models
{

    public partial class Makale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Makale()
        {
            EklenmeTarihi = DateTime.Today;
            this.Resimler = new HashSet<Resim>();
            this.Yorumlar = new HashSet<Yorum>();
            this.Etiketler = new HashSet<Etiket>();
            
        }
        public int MakaleID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public System.DateTime EklenmeTarihi { get; set; }
        public int? KategoriID { get; set; }
        public Nullable<int> GoruntulenmeSayisi { get; set; }
        public Nullable<int> Begeni { get; set; }
        public Nullable<int> KullaniciID { get; set; }

       
        public virtual Kategori Kategori { get; set; }
        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resimler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorumlar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etiket> Etiketler { get; set; }

    }
}
