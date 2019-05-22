using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Sepet
    {
        public int MusteriId { get; set; } //Hem PK Hem FK
        public DateTime OlusturulmaTarihi { get; set; }
        public decimal AraToplam { get {
                return Urunler.Sum(x => x.Fiyat);
            } }
        
        public virtual List<SepetUrun> Urunler { get; set; }
        public virtual Musteri Musteri { get; set; }

        public Sepet()
        {
            OlusturulmaTarihi = DateTime.Now;
            Urunler = new List<SepetUrun>();
            Musteri = new Musteri();
        }
    }

    public class SepetUrun
    {
        public int SepetUrunId { get; set; }
        public int SepetId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }

        public decimal Fiyat
        {
            get { return Adet * BirimFiyat; }
        }

        public virtual Sepet UrunSepet { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
