using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity.Models
{
  public  class Makale 
    {

        [Key]
        public int MakaleID { get; set; }

        [Required(ErrorMessage = "Başlık Zorunludur.")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Title should be 3-500 caracters long.", MinimumLength = 3)]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(2000)]
        [StringLength(2000, ErrorMessage = "Description should be 3-2000 caracters long.", MinimumLength = 3)]
        public string Tanım { get; set; }
        [Column(TypeName = "text")]
        public string Icerik { get; set; }
        public string MakaleResim { get; set; }
        public string MakaleVideo { get; set; }
        public string MakaleMuzik { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public string EklenmeGunu
        {
            get
            {
                TimeSpan gunfarki = DateTime.Today - EklemeTarihi;
                double year = (gunfarki.TotalDays / 365);
                if (gunfarki.Days >= 31)
                {
                    return gunfarki + " days ago";
                }
                else if (gunfarki.Hours >= 0)
                {
                    return gunfarki + " hours ago";
                }
                else if (((int)gunfarki.TotalDays / 365) == 1)
                {
                    return " 1 year ago";
                }
                else if (year >= 1)
                {
                    return year + " year ago";
                }
                return "";
            }
        }
        
        public virtual string YazarEmail { get; set; }
        //[ForeignKey("YazarEmail")]
        //public string  YazarEmail { get; set; }
        //public virtual Kullanici Kullanici { get; set; }
        public Makale()
        { Kullanici k = new Kullanici();
            EklemeTarihi = DateTime.Today;
            YazarEmail = k.Email;
        }

    }
}
