using Obs_Proje.Data;

namespace Obs_Proje.Models
{
    public class OgrenciViewModel
    {
        public int Id { get; set; }
        public string TamAdi { get; set; }
        public int OkulNo { get; set; }

        public virtual List<Ders> Dersler { get; set; }
        public virtual Bolum Bolum { get; set; }
        public virtual Adres Adres { get; set; }
    }
}
