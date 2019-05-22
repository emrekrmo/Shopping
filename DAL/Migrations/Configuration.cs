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
CÝNSÝYET	BAYAN
KORDON RENGÝ	Bakýr
KASA TÝPÝ	Plastik / Silikon
KADRAN ÞEKLÝ	Yuvarlak
ÇAP	43 mm
KADRAN RENGÝ	Rose
KORDON TÝPÝ	Alüminyum
KASA RENGÝ	Bakýr
TAKVÝM	Var
KRONOMETRE	Var
SUYA DAYANINIKLIÐI	0 Mt-50 Mt
MEKANÝZMA / EKRAN TÝPÝ	Quartz
CAM	Mineral";

                Urun u2 = new Urun();
                u2.UrunAdi = "Esprit Kadýn Kol Saati";
                u2.BirimFiyati = 500;
                u2.Aciklama = @"Sitemizde bulunan tüm Esprit Ürün Modelleri SAAT VE SAAT SANAYÝ TÝCARET A.Þ güvencesi altýndadýr. Alacaðýnýz bu ürün 2 yýl garanti kapsamýndadýr. Sipariþiniz onaylanmýþ orijinal garanti belgesi ve kutusu ile anlaþmalý kargo firmasý (MNG Kargo) tarafýndan adresinize teslim edilecektir. ";

                context.Urunler.Add(u1);
                context.Urunler.Add(u2);

                Musteri m1 = new Musteri()
                {
                    AdSoyad = "Duygu Öðünç",
                    Adres = "Falanca Mah. Filanca Sk. No:9 Ýstanbul",
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
