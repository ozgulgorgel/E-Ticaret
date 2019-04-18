using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class Resim
    {
        [Key]
        public int ResimID { get; set; }
        public string BuyukYol { get; set; }
        public string OrtaYol { get; set; }
        public string KucukYol { get; set; }
        public bool Varsayilan { get; set; }
        public byte SiraNo { get; set; }
        public int? UrunID { get; set; }
   
        public virtual ICollection<Marka> Markas { get; set; }
        public virtual Urun Urun { get; set; }
    }
}