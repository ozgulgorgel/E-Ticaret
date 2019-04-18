using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class MusteriAdres
    {
        public int MusteriAdresID { get; set; }
        public int  MusteriID { get; set; }
        public string Adres { get; set; }
        public string Adi { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}