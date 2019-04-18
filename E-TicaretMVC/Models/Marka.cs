using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class Marka
    {
        public int MarkaID { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int? ResimID { get; set; }
        public virtual Resim Resim { get; set; }
        public virtual ICollection<Urun> Uruns { get; set; }
    }
}