using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication8.Controllers
{
    public class KitapController : Controller
    {
        
        static List<Kitap> kitaplar = new List<Kitap>();
        static int id = 1;

       
        public IActionResult Index()
        {
            return View(kitaplar);
        }

        
        [HttpPost]
        public IActionResult Ekle(Kitap kitap)
        {
            kitap.Id = id++;
            kitaplar.Add(kitap);
            return RedirectToAction("Index");
        }

        
        public IActionResult Sil(int id)
        {
            var kitap = kitaplar.FirstOrDefault(k => k.Id == id);
            return View(kitap);
        }

       
        [HttpPost]
        public IActionResult SilOnay(int id)
        {
            var kitap = kitaplar.FirstOrDefault(k => k.Id == id);
            if (kitap != null)
            {
                kitaplar.Remove(kitap);
            }
            return RedirectToAction("Index");
        }

       
        public IActionResult Guncelle(int id)
        {
            var kitap = kitaplar.FirstOrDefault(k => k.Id == id);
            return View(kitap);
        }

       
        [HttpPost]
        public IActionResult Guncelle(Kitap kitap)
        {
            var eskiKitap = kitaplar.FirstOrDefault(k => k.Id == kitap.Id);

            if (eskiKitap != null)
            {
                eskiKitap.Ad = kitap.Ad;
                eskiKitap.Yazar = kitap.Yazar;
                eskiKitap.Fiyat = kitap.Fiyat;
                eskiKitap.Kategori = kitap.Kategori;
                eskiKitap.Ozet = kitap.Ozet;
            }

            return RedirectToAction("Index");
        }

       
        public IActionResult SiralaAdaGore()
        {
            var siraliListe = kitaplar
                .OrderBy(k => k.Ad)
                .ToList();

            return View("Index", siraliListe);
        }

        
        public IActionResult SiralaFiyataGore()
        {
            var siraliListe = kitaplar
                .OrderBy(k => k.Fiyat)
                .ToList();

            return View("Index", siraliListe);
        }


    }
}
