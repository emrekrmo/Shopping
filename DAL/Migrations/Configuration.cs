namespace DAL.Migrations
{
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.AlisverisContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.AlisverisContext context)
        {

            if (context.Urunler.Count() == 0)
            {
                Urun u1 = new Urun();
                u1.UrunAdi = "Swatch Gw188";
                u1.BirimFiyati = 222;
                u1.Aciklama = @"
C�NS�YET	BAYAN
KORDON RENG�	Bak�r
KASA T�P�	Plastik / Silikon
KADRAN �EKL�	Yuvarlak
�AP	43 mm
KADRAN RENG�	Rose
KORDON T�P�	Al�minyum
KASA RENG�	Bak�r
TAKV�M	Var
KRONOMETRE	Var
SUYA DAYANINIKLI�I	0 Mt-50 Mt
MEKAN�ZMA / EKRAN T�P�	Quartz
CAM	Mineral";

                Urun u2 = new Urun();
                u2.UrunAdi = "Esprit Kad�n Kol Saati";
                u2.BirimFiyati = 500;
                u2.Aciklama = @"Sitemizde bulunan t�m Esprit �r�n Modelleri SAAT VE SAAT SANAY� T�CARET A.� g�vencesi alt�ndad�r. Alaca��n�z bu �r�n 2 y�l garanti kapsam�ndad�r. Sipari�iniz onaylanm�� orijinal garanti belgesi ve kutusu ile anla�mal� kargo firmas� (MNG Kargo) taraf�ndan adresinize teslim edilecektir. ";

                context.Urunler.Add(u1);
                context.Urunler.Add(u2);

                Musteri m1 = new Musteri()
                {
                    AdSoyad = "Duygu ���n�",
                    Adres = "Falanca Mah. Filanca Sk. No:9 �stanbul",
                    Email = "d@d.com",
                    Sifre = "123456",
                    Telefon = "0212 123 45 67"
                };
                context.Musteriler.Add(m1);
                context.SaveChanges();
            }
        }
    }
}
