using System.Collections.Generic;

namespace Entity
{
    //POCO - Plain Old CLR Object
    public class Urun
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal BirimFiyati { get; set; }
        
        public virtual List<SepetUrun> SepetUrun { get; set; }
    }
}
