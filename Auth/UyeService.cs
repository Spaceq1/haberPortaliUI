﻿using haberPortaliAPI.Models;
using haberPortaliAPI.ViewModel;
using System.Linq;

namespace haberPortaliAPI.Auth
{
    public class UyeService
    {
        MyoBlog29DBEntities db = new MyoBlog29DBEntities();

        public UyeModel UyeOturumAc(string kadi, string parola)
        {
            UyeModel uye = db.Uye.Where(s => s.KullaniciAdi == kadi && s.Sifre == parola).Select(x => new UyeModel()
            {
                UyeId = x.UyeId,
                AdSoyad = x.AdSoyad,
                Email = x.Email,
                KullaniciAdi = x.KullaniciAdi,
                Foto = x.Foto,
                Sifre = x.Sifre,
                UyeAdmin = x.UyeAdmin
            }).SingleOrDefault();
            return uye;

        }
    }
}