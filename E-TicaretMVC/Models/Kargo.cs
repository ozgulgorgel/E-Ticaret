using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class Kargo
    {
        public int KargoID { get; set; }
        public string SirketAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Satis> Satis { get; set; }
    }
}