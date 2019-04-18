using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class Kategori
    {


        public int KategoriID { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        
        //public virtual ICollection<OzellikTip> OzellikTips { get; set; }
        public virtual ICollection<Urun> Uruns { get; set; }
    }
}