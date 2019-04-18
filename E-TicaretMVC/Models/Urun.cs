using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
      
        public int? KategoriID { get; set; }
        public int MarkaID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Marka Marka { get; set; }
        public virtual ICollection<Resim> Resims { get; set; }
        public virtual ICollection<SatisDetay> SatisDetays { get; set; }
        public virtual ICollection<UrunOzellik> UrunOzelliks { get; set; }
    }
}