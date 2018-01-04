using DomainEntity;
using DomainEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    
    public class MakaleRep : BaseRepository<Makale> { }

    public class KategoriRep : BaseRepository<Kategori> { }

    public class YorumRep : BaseRepository<Yorum> { }
}
