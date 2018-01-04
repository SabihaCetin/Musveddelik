using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.Models
{
    public partial class Kategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategori()
        {
            this.Makale = new HashSet<Makale>();
        }

        public int KAtegoriID { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Makale> Makale { get; set; }
    }
}
