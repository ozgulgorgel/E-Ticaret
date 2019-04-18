using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
     
        public virtual ICollection<MusteriAdres> MusteriAdres { get; set; }
        public virtual ICollection<Satis> Satis { get; set; }
    }
}