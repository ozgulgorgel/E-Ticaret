using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class Satis
    {
        public int SatisID { get; set; }
        public int MusteriID { get; set; }
        public DateTime SatisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public bool SepetteMi { get; set; }
        public int KargoID { get; set; }
        public int SiparisDurumID { get; set; }
        public string KargoTakipNo { get; set; }
        public virtual Kargo Kargo { get; set; }
        public virtual Musteri Musteri { get; set; }
        public virtual SiparisDurum SiparisDurum { get; set; }
        public virtual ICollection<SatisDetay> SatisDetays { get; set; }
    }
}