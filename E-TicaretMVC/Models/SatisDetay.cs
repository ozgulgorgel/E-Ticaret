using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class SatisDetay
    {
        [Key]
        public int SatisID { get; set; }
        public int UrunID { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public double Indirim { get; set; }
        public virtual Satis Satis { get; set; }
        public virtual Urun Urun { get; set; }
    }
}