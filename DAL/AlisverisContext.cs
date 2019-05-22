using Entity;
using System.Data.Entity;

namespace DAL
{
    public class AlisverisContext : DbContext
    {
        public AlisverisContext() :base("AlisverisCon")
        {
            // virtual oto getirmesin, include gereksin
           // this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Sepet> Sepetler { get; set; }
        public virtual DbSet<SepetUrun> SepetUrunler { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            #region TabloAyarlari
            mb.Entity<Urun>()
                .ToTable("tblUrunler")
                .HasKey(x => x.UrunId)
                .HasIndex(x => x.BirimFiyati)
                .HasName("IX_Fiyat");

            mb.Entity<Musteri>()
                .HasKey(x => x.MusteriId);

            mb.Entity<Sepet>()
                .HasKey(x => x.MusteriId);

            //Yoğun hatalar sebebiyle iptal
            //mb.Entity<SepetUrun>() //Composite key
            //    .HasKey(x => new { x.SepetId, x.UrunId });

            mb.Entity<SepetUrun>().HasKey(x => x.SepetUrunId);

            #endregion

            //Preprocessor Directives (# ile başlayanlar)
            #region PropAyarlari

            mb.Entity<Urun>()
                .Property(x => x.UrunAdi)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode()
                .HasColumnType("nvarchar");

            mb.Entity<Musteri>()
                .Property(x => x.AdSoyad)
                .IsRequired()
                .HasMaxLength(120);

            mb.Entity<Musteri>()
                .Property(x => x.Email)
                .HasMaxLength(300);

            mb.Entity<Musteri>()
                .Property(x => x.Sifre)
                .HasMaxLength(16);

            mb.Entity<Musteri>()
                .Property(x => x.Telefon)
                .HasMaxLength(25);

            #endregion

            #region Iliskiler
            //1-1
            mb.Entity<Musteri>()
                .HasRequired(mus => mus.Sepet)
                .WithRequiredPrincipal(sepet => sepet.Musteri);

            //1-many
            mb.Entity<Sepet>()
                .HasMany(sepet => sepet.Urunler)
                .WithRequired(surun => surun.UrunSepet)
                .HasForeignKey(x => x.SepetId);

            //1-many
            mb.Entity<SepetUrun>()
                .HasRequired(surun => surun.Urun)
                .WithMany(urun => urun.SepetUrun)
                .HasForeignKey(surun => surun.UrunId);

            #endregion

            base.OnModelCreating(mb);
        }
    }
}
