using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class SepetManager
    {
        AlisverisContext _db;

        public SepetManager(AlisverisContext db)
        {
            _db = db;
        }

        public void UrunEkle(int urunId, int musteriId, int adet)
        {
            var sepet = _db.Sepetler.Find(musteriId);

            var sepeturun = sepet.Urunler.FirstOrDefault(x => x.UrunId == urunId);

            if (sepeturun == null)
            { //bu ürünü ilk defa sepete atıyoruz
                SepetUrun surun = new SepetUrun();
                surun.SepetId = sepet.MusteriId;
                surun.UrunId = urunId;
                surun.Adet = adet;
                surun.BirimFiyat = _db.Urunler.Find(urunId).BirimFiyati;
                _db.SepetUrunler.Add(surun);
            }
            else
            {
                //bu ürünü daha önce de almışız, olanın adetini artıralım
                sepeturun.Adet += adet;
                _db.Entry(sepeturun).State = EntityState.Modified;
            }
        }

        public void UrunSil(int urunId, int musteriId)
        {
            var sepet = _db.Sepetler.Find(musteriId);

            var sepeturun = sepet.Urunler.FirstOrDefault(x => x.UrunId == urunId);

            _db.SepetUrunler.Remove(sepeturun);
        }

        public Sepet SepetGetir(int musteriId)
        {
            return _db.Sepetler.Find(musteriId);
        }
    }
}
