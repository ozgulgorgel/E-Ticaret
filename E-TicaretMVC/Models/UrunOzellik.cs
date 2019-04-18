using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_TicaretMVC.Models
{
    public class UrunOzellik
    {
        [Key]
    

        public int UrunID { get; set; }
        public int OzellikTipID { get; set; }
        public int OzellikDegerID { get; set; }
        //public virtual OzellikDeger OzellikDeger { get; set; }
        //public virtual OzellikTip OzellikTip { get; set; }
        public virtual Urun Urun { get; set; }
    }
}