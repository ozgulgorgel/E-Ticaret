using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class SiparisDurum
    {
        public int SiparisDurumID { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public virtual ICollection<Satis> Satis { get; set; }
    }
}