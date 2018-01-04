using DomainEntity;
using DomainEntity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class MyContext : IdentityDbContext<Kullanici>
    {
       public static MyContext db { get; set; }
        public MyContext() : base("DefaultConnection")
        {

        }
        public virtual DbSet<Makale> Makaleler { get; set; }
  
       // public virtual DbSet<Kullanici> Kullanıcılar { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Yorum> Yorumlar { get; set; }
        public virtual DbSet<Etiket> Etiketler { get; set; }
        public virtual DbSet<Resim> Resimler { get; set; }

    }
}
