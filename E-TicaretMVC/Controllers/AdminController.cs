using E_TicaretMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretMVC.Controllers
{
    public class AdminController : Controller
    {
        EticaretContext db = new EticaretContext();
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Urunler()
        {
            var urunler = db.Uruns.ToList();
            return View(urunler);
        }
        public ActionResult UrunEkle()
        {
            ViewBag.Kategoriler = db.Kategoris.ToList();
            ViewBag.Markalar = db.Markas.ToList();
            return View();
        }
      
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {

            Urun urun = new Urun();
            urun.Adi = u.Adi;
            urun.Aciklama = u.Aciklama;
            urun.AlisFiyat = u.AlisFiyat;
            urun.SatisFiyat = u.SatisFiyat;
            urun.Kategori.Adi = u.Kategori.Adi;
            urun.Marka.Adi = u.Marka.Adi;
            db.Uruns.Add(urun);
            db.SaveChanges();

            return RedirectToAction("Urunler");
            
        }
        public ActionResult UrunSil(int id)
        {
            Urun urn = db.Uruns.FirstOrDefault(x => x.UrunID == id);
            db.Uruns.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("Urunler");
        }

        public ActionResult UrunGuncelle(int id)
        {
            Urun u = db.Uruns.Where(x => x.UrunID == id).FirstOrDefault();
            return View(u);
        }
      

        //[HttpPost]
        //public ActionResult UrunGuncelle(Urun u)
        //{
        //    Urun degisen = db.Uruns.Find(u.UrunID);
        //    degisen.Adi = u.Adi;
        //    degisen.Aciklama = u.Aciklama;
        //    degisen.AlisFiyat = u.AlisFiyat;
        //    degisen.SatisFiyat = u.SatisFiyat;
        //    degisen.EklenmeTarihi = u.EklenmeTarihi;
        //    db.SaveChanges();
        //    return RedirectToAction("Urunler");
        //}
        //public ActionResult UrunSil(int id)
        //{
        //    Urun u = db.Uruns.Where(x => x.UrunID == id).FirstOrDefault();
        //    db.Uruns.Remove(u);
        //    db.SaveChanges();
        //    return View(u);
        //}
       
        public ActionResult Markalar()
        {
            var markalar = db.Markas.ToList();
            return View(markalar);
        }
        public ActionResult MarkaEkle()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult MarkaEkle(Marka mrk,HttpPostedFileBase fileUpload)
        //{ 
        //    int resimId =-1;
        //    if(fileUpload!=null)
        //    {
        //        Image img =Image.FromStream(fileUpload.InputStream);
        //        int width = Convert.ToInt32
        //        (ConfigurationManager.AppSettings["MarkaWidth"].ToString());
        //        int height = Convert.ToInt32
        //        (ConfigurationManager.AppSettings["MarkaHeight"].ToString());

        //        string name="/Content/MarkaResim/"+Guid.NewGuid()+Path.GetExtension(fileUpload.FileName);

        //        Bitmap bm = new Bitmap(img, width, height);
        //        bm.Save(Server.MapPath(name));
        //        Resim rsm = new Resim();
        //        rsm.OrtaYol = name;
        //        db.Resims.Add(rsm);
        //        db.SaveChanges();
        //        //if (rsm.ResimID != 0)
        //        //    resimId = rsm.ResimID;

        //    }
        //    if (resimId!=-1)
        //    mrk.ResimID = resimId;
        //    db.Markas.Add(mrk);
        //    db.SaveChanges();
        //    return RedirectToAction("Markalar");

        //}
        public ActionResult MarkaEkle(Marka mrk, HttpPostedFileBase fileUpload)
        {
            int resimId = -1;
            if (fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                int width = Convert.ToInt32(ConfigurationManager.AppSettings["MarkaWidth"].ToString());
                int height = Convert.ToInt32(ConfigurationManager.AppSettings["MarkaHeight"].ToString());

                string name = "/Content/MarkaResim/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                Bitmap bm = new Bitmap(img, width, height);
                bm.Save(Server.MapPath(name));

                Resim rsm = new Resim();
                rsm.OrtaYol = name;

                db.Resims.Add(rsm);
                db.SaveChanges();

                if (rsm.ResimID != null)
                    resimId = rsm.ResimID;
            }
            if (resimId != -1)
                mrk.ResimID = resimId;
            db.Markas.Add(mrk);
            db.SaveChanges();
            return RedirectToAction("Markalar");
        }
        public ActionResult MarkaSil(int id)
        {
            Marka mrk = db.Markas.Where(x => x.MarkaID == id).FirstOrDefault();
            db.Markas.Remove(mrk);
            db.SaveChanges();
            return RedirectToAction("Markalar");
        }
        public ActionResult MarkaGuncelle(int id)
        {
            Marka u = db.Markas.Where(x => x.MarkaID == id).FirstOrDefault();
            return View(u);
        }
        [HttpPost]
        public ActionResult MarkaGuncelle(Marka u)
        {
            Marka degisen = db.Markas.Find(u.MarkaID);
            degisen.Adi = u.Adi;
            degisen.Aciklama = u.Aciklama;
            degisen.Resim = u.Resim;

            db.SaveChanges();
            return RedirectToAction("Markalar");
        }
        public ActionResult Kategoriler()
        {
            return View(db.Kategoris.ToList());
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori ktg)
        {
        
            db.Kategoris.Add(ktg);
            db.SaveChanges();
            return RedirectToAction("Kategoriler");
        }
        public ActionResult KategoriGuncelle(int id)
        {
            Kategori u = db.Kategoris.Where(x => x.KategoriID == id).FirstOrDefault();
            return View(u);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori u)
        {
            Kategori degisen = db.Kategoris.Find(u.KategoriID);
            degisen.Adi = u.Adi;
            degisen.Aciklama = u.Aciklama;
            
            db.SaveChanges();
            return RedirectToAction("Kategoriler");
        }

        public ActionResult KategoriSil(int id)
        {
            Kategori ktg = db.Kategoris.FirstOrDefault(x => x.KategoriID == id);
            db.Kategoris.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Kategoriler");
            
        }
        //public ActionResult OzellikTipleri()
        //{
        //    return View(db.OzellikTips.ToList());
        //}
        //public ActionResult OzellikTipEkle()
        //{
        //    return View(db.Kategoris.ToList());
        //}
        //[HttpPost]
        //public ActionResult OzellikTipEkle(OzellikTip ot)
        //{
        //    db.OzellikTips.Add(ot);
        //    db.SaveChanges();
        //    return RedirectToAction("OzellikTipleri");
        //}
        //public ActionResult OzellikDegerleri()
        //{
        //    return View(db.OzellikDegers.ToList());
        //}
        //public ActionResult OzellikDegerEkle()
        //{
        //    return View(db.OzellikTips.ToList());
        //}
        //[HttpPost]
        //public ActionResult OzellikDegerEkle(OzellikDeger oz)
        //{
        //    db.OzellikDegers.Add(oz);
        //    db.SaveChanges();
        //    return RedirectToAction("OzellikDegerleri");
        //}
        public ActionResult UrunOzellikleri()
        {
            return View(db.UrunOzelliks.ToList());
        }
        public ActionResult UrunOzellikSil(int urunId,int tipId,int degerId)
        {
            UrunOzellik uo = db.UrunOzelliks.FirstOrDefault(x => x.UrunID == urunId && x.OzellikTipID == tipId && x.OzellikDegerID == degerId);
            db.UrunOzelliks.Remove(uo);
            db.SaveChanges();
            return RedirectToAction("UrunOzellikleri");
        }
        public ActionResult UrunOzellikEkle()
        { 
            return View(db.Uruns.ToList());
        }
        public ActionResult UrunResimEkle(int id)
        {

            return View(id);
                
        }
          [HttpPost]
          
        public ActionResult UrunResimEkle(int uId, HttpPostedFileBase fileupload)
        {
            if (fileupload != null)
            {
                Image img = Image.FromStream(fileupload.InputStream);

                Bitmap ortaResim = new Bitmap(img, Settings.UrunOrtaBoyut);
                Bitmap buyukResim = new Bitmap(img, Settings.UrunBuyukBoyut);

                string ortaYol = "/Content/UrunImg/Orta/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);
                string buyukYol = "/Content/UrunImg/Buyuk/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);

                ortaResim.Save(Server.MapPath(ortaYol));
                buyukResim.Save(Server.MapPath(buyukYol));

                Resim rsm = new Resim();
                rsm.BuyukYol = buyukYol;
                rsm.OrtaYol = ortaYol;
                rsm.UrunID = uId;

                if (db.Resims.FirstOrDefault(x => x.UrunID == uId && x.Varsayilan == false) != null)
                    rsm.Varsayilan = true;
                else
                    rsm.Varsayilan = false;
                db.Resims.Add(rsm);
                db.SaveChanges();
                return View(uId);
            }
            return View(uId); 
        }
       
          public ActionResult SliderResimleri()
          {
              return View();

          }

         
           [HttpPost]
           public ActionResult SliderResimEkle(HttpPostedFileBase fileupload)
           {
               if (fileupload != null)
               {
                   Image img = Image.FromStream(fileupload.InputStream);

                   Bitmap bmp = new Bitmap(img, Settings.SliderResimBoyut);

                   string yol = "/Content/SliderResim/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);
                   bmp.Save(Server.MapPath(yol));

                   Resim rsm = new Resim();
                   rsm.BuyukYol = yol;
                   db.Resims.Add(rsm);
                   db.SaveChanges();
               }
               return RedirectToAction("SliderResimleri");
           }

	}
}