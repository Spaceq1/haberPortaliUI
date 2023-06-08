using haberPortaliAPI.Models;
using haberPortaliAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace haberPortaliAPI.Controllers
{

    public class ServisController : ApiController
    {
        haberPortaliDBEntities db = new haberPortaliDBEntities();
        SonucModel sonuc = new SonucModel();

        #region Kategori

        [HttpGet]
        [Route("api/kategoriliste")]

        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.Kategori.Select(x => new KategoriModel()
            {
                kategoriId = x.KategoriId,
                kategoriAdi = x.KategoriAdi,
                katHaberSay = x.Haber.Count
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/kategoribyid/{katId}")]
        public KategoriModel KategoriById(int katId)
        {
            KategoriModel kayit = db.Kategori.Where(s => s.KategoriId == katId).Select(x => new KategoriModel()
            {
                kategoriId = x.KategoriId,
                kategoriAdi = x.KategoriAdi,
                katHaberSay = x.Haber.Count
            }).SingleOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if (db.Kategori.Count(s => s.KategoriAdi == model.KategoriAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kategori Adı Kayıtlıdır!";
                return sonuc;
            }

            Kategori yeni = new Kategori();
            yeni.KategoriAdi = model.KategoriAdi;
            db.Kategori.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId == model.kategoriId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            kayit.kategoriAdi = model.kategoriAdi;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kategorisil/{katId}")]
        public SonucModel KategoriSil(int katId)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId == katId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            if (db.haber.Count(s => s.kategoriId == katId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde haber Kayıtlı Kategori Silinemez!";
                return sonuc;
            }

            db.Kategori.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi";
            return sonuc;
        }
        #endregion

        #region Haber


        [HttpGet]
        [Route("api/haberliste")]
        public List<haberModel> haberListe()
        {
            List<haberModel> liste = db.haber.Select(x => new haberModel()
            {
                haberId = x.haberId,
                Baslik = x.Baslik,
                Icerik = x.Icerik,
                KategoriId = x.KategoriId,
                KategoriAdi = x.Kategori.KategoriAdi,
                Tarih = x.Tarih,

            }).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/haberlistesoneklenenler/{s}")]
        public List<haberModel> haberListeSonEklenenler(int s)
        {
            List<haberModel> liste = db.haber.OrderByDescending(o => o.haberId).Take(s).Select(x => new haberModel()
            {
                haberId = x.haberId,
                Baslik = x.Baslik,
                Icerik = x.Icerik,
                KategoriId = x.KategoriId,
                KategoriAdi = x.Kategori.KategoriAdi,
                Tarih = x.Tarih,

            }).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/haberlistebykatid/{katId}")]
        public List<haberModel> haberListeByKatId(int katId)
        {
            List<haberModel> liste = db.haber.Where(s => s.KategoriId == katId).Select(x => new haberModel()
            {
                haberId = x.haberId,
                Baslik = x.Baslik,
                Icerik = x.Icerik,
                KategoriId = x.KategoriId,
                KategoriAdi = x.Kategori.KategoriAdi,
                Tarih = x.Tarih,

            }).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/haberlistebyuyeid/{uyeId}")]
        public List<haberModel> haberListeByUyeId(int uyeId)
        {
            List<haberModel> liste = db.haber.Where(s => s.UyeId == uyeId).Select(x => new haberModel()
            {
                haberId = x.haberId,
                Baslik = x.Baslik,
                Icerik = x.Icerik,
                KategoriId = x.KategoriId,
                KategoriAdi = x.Kategori.KategoriAdi,
                Tarih = x.Tarih,

            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/haberbyid/{haberId}")]
        public haberModel haberById(int haberId)
        {
            haberModel kayit = db.haber.Where(s => s.haberId == haberId).Select(x => new haberModel()
            {
                haberId = x.haberId,
                Baslik = x.Baslik,
                Icerik = x.Icerik,
                KategoriId = x.KategoriId,
                KategoriAdi = x.Kategori.KategoriAdi,
                Tarih = x.Tarih,
            }).SingleOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/haberekle")]
        public SonucModel haberEkle(haberModel model)
        {
            if (db.haber.Count(s => s.Baslik == model.Baslik) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen haber Başlığı Kayıtlıdır!";
                return sonuc;
            }

            haber yeni = new haber();
            yeni.Baslik = model.Baslik;
            yeni.Icerik = model.Icerik;
            yeni.Tarih = model.Tarih;
            yeni.KategoriId = model.KategoriId;
            db.haber.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "haber Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/haberduzenle")]
        public SonucModel haberDuzenle(haberModel model)
        {
            haber kayit = db.haber.Where(s => s.haberId == model.haberId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.Baslik = model.Baslik;
            kayit.Icerik = model.Icerik;
            kayit.Okunma = model.Okunma;
            kayit.KategoriId = model.KategoriId;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "haber Düzenlendi";
            return sonuc;

        }

        [HttpDelete]
        [Route("api/habersil/{haberId}")]
        public SonucModel haberSil(int haberId)
        {
            haber kayit = db.haber.Where(s => s.haberId == haberId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            if (db.Yorum.Count(s => s.haberId == haberId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Yorum Kayıtlı haber Silinemez!";
                return sonuc;
            }

            db.haber.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "haber Silindi";
            return sonuc;
        }
        #endregion

        #region Üye

        [HttpGet]
        [Route("api/uyeliste")]
        public List<UyeModel> UyeListe()
        {
            List<UyeModel> liste = db.Uye.Select(x => new UyeModel()
            {
                UyeId = x.UyeId,
                AdSoyad = x.AdSoyad,
                Email = x.Email,
                KullaniciAdi = x.KullaniciAdi,
                Sifre = x.Sifre,
                UyeAdmin = x.UyeAdmin
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/uyebyid/{uyeId}")]
        public UyeModel UyeById(int uyeId)
        {
            UyeModel kayit = db.Uye.Where(s => s.UyeId == uyeId).Select(x => new UyeModel()
            {
                UyeId = x.UyeId,
                AdSoyad = x.AdSoyad,
                Email = x.Email,
                KullaniciAdi = x.KullaniciAdi,
                Foto = x.Foto,
                Sifre = x.Sifre,
                UyeAdmin = x.UyeAdmin
            }).SingleOrDefault();

            return kayit;
        }

        [HttpPost]
        [Route("api/uyeekle")]
        public SonucModel UyeEkle(UyeModel model)
        {
            if (db.Uye.Count(s => s.KullaniciAdi == model.KullaniciAdi || s.Email == model.Email) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kullanıcı Adı veya E-Posta Adresi Kayıtlıdır!";
                return sonuc;
            }

            Uye yeni = new Uye();
            yeni.AdSoyad = model.AdSoyad;
            yeni.Email = model.Email;
            yeni.KullaniciAdi = model.KullaniciAdi;
            yeni.Foto = model.Foto;
            yeni.Sifre = model.Sifre;
            yeni.UyeAdmin = model.UyeAdmin;

            db.Uye.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/uyeduzenle")]
        public SonucModel UyeDuzenle(UyeModel model)
        {
            Uye kayit = db.Uye.Where(s => s.UyeId == model.UyeId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;
            }
            kayit.AdSoyad = model.AdSoyad;
            kayit.Email = model.Email;
            kayit.KullaniciAdi = model.KullaniciAdi;
            kayit.Foto = model.Foto;
            kayit.Sifre = model.Sifre;
            kayit.UyeAdmin = model.UyeAdmin;

            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Düzenlendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/uyesil/{uyeId}")]
        public SonucModel UyeSil(int uyeId)
        {
            Uye kayit = db.Uye.Where(s => s.UyeId == uyeId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;
            }

            if (db.haber.Count(s => s.UyeId == uyeId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde haber Kaydı Olan Üye Silinemez!";
                return sonuc;
            }

            if (db.Yorum.Count(s => s.UyeId == uyeId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Yorum Kaydı Olan Üye Silinemez!";
                return sonuc;
            }

            db.Uye.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Silindi";
            return sonuc;
        }
        #endregion

    
    }
}
