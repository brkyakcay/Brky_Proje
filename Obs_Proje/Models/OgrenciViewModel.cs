using Obs_Proje.Data;

namespace Obs_Proje.Models
{
    public class OgrenciViewModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int OkulNo { get; set; }
        public int DersSayisi { get; set; }
        public string Dersleri { get; set; }

        public virtual string BolumAdi { get; set; }
    }

    
}
