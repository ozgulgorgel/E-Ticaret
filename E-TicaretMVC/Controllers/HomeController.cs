using E_TicaretMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretMVC.Controllers
{
    public class HomeController : Controller
    {
        EticaretContext db = new EticaretContext();
        public ActionResult Index()
        {
            return View();
             
        }
        public void SepetUrunAdetDusur(int id)
        {

            if (HttpContext.Session["AktifSepet"] != null)
            {
                Sepet s = (Sepet)HttpContext.Session["AktifSepet"];
                if (s.Urunler.FirstOrDefault(x => x.Urun.UrunID == id).Adet > 1)
                    s.Urunler.FirstOrDefault(x => x.Urun.UrunID == id).Adet--;
                else
                {
                    SepetItem si = s.Urunler.FirstOrDefault(x => x.Urun.UrunID == id);
                    s.Urunler.Remove(si);
                }

            }
        }
        public PartialViewResult Sepet()
        {
            return PartialView();

        }
       
        public PartialViewResult Slider()
        {
            var data = db.Resims.Where(x => x.BuyukYol.Contains("Slider")).ToList();
            return PartialView(data);

        }
        public PartialViewResult YeniUrunler()
        {
            var data = db.Uruns.ToList();
            return PartialView(data);

        }
        public PartialViewResult Servisler()
        {
            return PartialView();

        }
       
        public PartialViewResult Markalar()
        {
            var data = db.Markas.ToList();
            return PartialView(data);

        }
        public ActionResult SliderResimleri()
        {
            return View();

        }
        public ActionResult Sepetim()
        {
            //eğer sepet boş değilse "AktifSepet"i View'e gönder
            if (HttpContext.Session["AktifSepet"] != null)
                return View((Sepet)HttpContext.Session["AktifSepet"]);
            else//sepet boşsa Model'e birşey gönderilmez
                return View();
        }
        public void SepeteEkle(int id)
        {
            SepetItem si = new SepetItem();
            Urun u = db.Uruns.FirstOrDefault(x => x.UrunID == id);
            si.Urun = u;
            si.Adet = 1;
            si.Indirim = 0;
            Sepet s = new Sepet();
            s.SepeteEkle(si);
       
        }
        public PartialViewResult MiniSepetWidget()
        {
            if (HttpContext.Session["AktifSepet"] != null)
                return PartialView((Sepet)HttpContext.Session["AktifSepet"]);
            else
                return PartialView();

        }
        public ActionResult UrunDetay(string id)
        {
            Urun u = db.Uruns.FirstOrDefault(x => x.Adi == id);
            return View(u);
        }
        public ActionResult Urunler(int id)
        {
            return View(db.Uruns.Where(x => x.KategoriID == id)); //o id degerine sahip ürünü parametre olarak al
        }
       
        public PartialViewResult Kategoriler()
        {
            return PartialView(db.Kategoris.ToList());
        }
        public PartialViewResult SideKategori()
        {
            return PartialView(db.Kategoris.ToList());
        }
        public PartialViewResult SideMarka()
        {
            return PartialView(db.Markas.ToList());
        }
        public ActionResult MarkalaraGoreUrunler(int id)
        {
            return View(db.Uruns.Where(x => x.MarkaID == id)); //o id degerine sahip ürünü parametre olarak al
        }

    }
}