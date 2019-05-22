using BLL.Services;
using DAL;
using Entity;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class MusteriManager
    {
        AlisverisContext _db;
        IEmailService _emailService;

        public MusteriManager(AlisverisContext db, IEmailService emailService)
        {
            _db = db;
            _emailService = emailService;
        }

        public bool Kayit(Musteri yeni)
        {
            _db.Musteriler.Add(yeni);
            return _db.SaveChanges() > 0;
        }

        public Musteri GirişYap(string email, string sifre)
        {
            return _db.Musteriler.FirstOrDefault(x => x.Email == email && x.Sifre == sifre);
        }
        public bool SifreDeğiştir(int id, string eskisifre, string yenisifre)
        {
            var kisi = _db.Musteriler.Find(id);
            if (kisi.Sifre == eskisifre)
            {
                kisi.Sifre = yenisifre;
                _db.Entry(kisi).State = EntityState.Modified;
                return _db.SaveChanges() > 0;
            }
            return false;
        }
        public void SifreHatirlat(string email)
        {
            var kisi = _db.Musteriler.FirstOrDefault(x => x.Email == email);
            if (kisi != null)
            {
                EmailViewModel mail = new EmailViewModel();
                mail.To = email;
                mail.Subject = "Şifre Hatırlatma";
                mail.IsHtml = true;
                mail.Message = @"
                <h1>Şifre Hatırlatma</h1>
<p>Şifreniz: <b>" + kisi.Sifre + "</b></p>";

                try
                {
                    _emailService.SendMail(mail);
                }
                catch { }
            }
        }

    }
}
